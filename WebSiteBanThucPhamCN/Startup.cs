using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;

using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using WebSiteBanThucPhamCN.Services;
using WebSiteBanThucPhamCN.Models;

using Microsoft.OpenApi.Models;
using System.Linq;
using Microsoft.Extensions.Hosting;

namespace WebSiteBanThucPhamCN
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();
            var mailsettings = Configuration.GetSection("MailSettings");

            services.Configure<MailSettings>(mailsettings);

            services.AddTransient<SendMailService>();



            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                 {
                     builder.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod();
                 });
            });

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBoundaryLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(option =>
             {
                 option.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidIssuer = "https://localhost:44376",
                     ValidAudience = "https://localhost:44376",
                     //ValidIssuer = "http://tuanan-001-site1.etempurl.com",
                     //ValidAudience = "http://tuanan-001-site1.etempurl.com",
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")),
                 };
             });
            //Enable CORS
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
            //    .AllowAnyHeader());
            //});
            //JSON Serializer
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
            .Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
            = new DefaultContractResolver());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",

                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.UseCors(options=>options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
          
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
               
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Upload")),
                RequestPath = new PathString("/wwwroot/Upload")
            });
            app.UseCors("EnableCORS");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapGet("/TestSendMail", async (context) =>
                {
                    var message = await MailUtils.MailUtils.SendMail("ngovotuananh@gmail.com", "ngovotuananh@gmail.com", "TEST", "Xin chao");
                    await context.Response.WriteAsync(message);
                });
                endpoints.MapGet("/TestGmail", async (context) =>
                {
                    var message = await MailUtils.MailUtils.SendGmail("ngovotuananh@gmail.com", "ngovotuanan1@gmail.com", "TEST", "Xin chao", "ngovotuananh@gmail.com", "123");
                    await context.Response.WriteAsync(message);
                });
                endpoints.MapPost("/GmailService/{OrderId}", async (context) =>
                {
                    UserSv userSv = new UserSv();
                    OrderSv orderSv = new OrderSv();
                    string OrderId = context.GetRouteValue("OrderId").ToString();
                    TblOrder tblOrder = orderSv.GetOrderByOrderId(int.Parse(OrderId));

                    TblUser tblUser = userSv.GetProfileById(tblOrder.CustomerId.ToString());
                    var sendMailService = context.RequestServices.GetService<SendMailService>();
                    var mailContent = new MailContent();
                    mailContent.To = tblUser.Email.ToString();
                    mailContent.Subject = "Cảm ơn " + tblUser.Fullname.ToString();
                    mailContent.Body = "<h2>Chúng tôi đã nhận được đơn hàng của bạn.</h2> <br> <p>Thông tin đơn hàng</p><br> " + " Mã dơn hàng:" + tblOrder.OrderId + " <br>Giá trị đơn: " + tblOrder.Total + " <br>Đơn hàng ngày: " + tblOrder.OrderDate + "<br> Cảm ơn vì đã sử dụng dịch vụ của chúng tôi!!";
                    var kq = await sendMailService.SendMail(mailContent);


                    //string Id = context.GetRouteValue("id").ToString();
                    //TblUser tblUser = userSv.GetProfileById(Id);
                    //var sendMailService = context.RequestServices.GetService<SendMailService>();
                    //var mailContent = new MailContent();
                    //mailContent.To = tblUser.Email.ToString();
                    //mailContent.Subject = "Cảm ơn " + tblUser.Fullname.ToString();
                    //mailContent.Body = "<h2>Chúng tôi đã nhận được đơn hàng của bạn.</h2> <br> <br>Đơn hàng ngày: " + DateTime.Now.ToShortDateString() + "<br> Cảm ơn vì đã sử dụng dịch vụ của chúng tôi!!";
                    //var kq = await sendMailService.SendMail(mailContent);
                    //await context.Response.WriteAsync("");


                });
            });


        }

        private RequestDelegate async(object context)
        {
            throw new NotImplementedException();
        }
    }
}
