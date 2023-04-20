// See https://aka.ms/new-console-template for more information
using ConsoleCrudMoex;
using Microsoft.Extensions.Configuration;
using MoexEntity;
using Serilog;

if (!Directory.Exists("logs"))
{
    Directory.CreateDirectory("logs");
}

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File($"logs/{DateTime.Now:yyyyMMdd}.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

// Custom for entity postgresql
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false);

var config = builder.Build();

var connectionString = config["postgres:connection"];
Log.Information($"Инициализация postgres = {connectionString}");

var dirbonds = config["moex:dirbonds"];
Log.Information($"Папка dirbonds = {dirbonds}");

var dirbonddescription = config["moex:dirbonddescription"];
Log.Information($"Папка dirbonddescription  = {dirbonddescription}");

var direurobonddescription = config["moex:direurobonddescription"];
Log.Information($"Папка direurobonddescription = {direurobonddescription}");

var dircoupons = config["moex:dircoupons"];
Log.Information($"Папка dircoupons = {dircoupons}");

var diramortization = config["moex:diramortization"];
Log.Information($"Папка diramortization = {diramortization}");

var diroffers = config["moex:diroffers"];
Log.Information($"Папка diroffers = {diroffers}");

var dirsharedescription = config["moex:dirsharedescription"];
Log.Information($"Папка dirsharedescription = {dirsharedescription}");

var dirshares = config["moex:dirshares"];
Log.Information($"Папка dirshares = {dirshares}");

// Add Copages to project
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

try
{
    Log.Information($"Работаем с BondEntity");
    Tools<BondEntity>.EncodingPageNumber = 1251;
    await Tools<BondEntity>.AddDb(dirbonds, connectionString);
}
catch { }

try
{
    Log.Information($"Работаем с BondDescriptionEntity");
    Tools<BondDescriptionEntity>.EncodingPageNumber = 1251;
    await Tools<BondDescriptionEntity>.AddDb(dirbonddescription, connectionString);
}
catch { }

try
{
    Log.Information($"Работаем с EurobondDescriptionEntity");
    Tools<EurobondDescriptionEntity>.EncodingPageNumber = 1251;
    await Tools<EurobondDescriptionEntity>.AddDb(direurobonddescription, connectionString);
}
catch { }

try
{
    Log.Information($"Работаем с CouponEntity");
    Tools<CouponEntity>.EncodingPageNumber = 1251;
    await Tools<CouponEntity>.AddDb(dircoupons, connectionString);
}
catch { }

try
{
    Log.Information($"Работаем с AmortizationEntity");
    Tools<AmortizationEntity>.EncodingPageNumber = 1251;
    await Tools<AmortizationEntity>.AddDb(diramortization, connectionString);
}
catch { }

try
{
    Log.Information($"Работаем с OffersEntity");
    Tools<OffersEntity>.EncodingPageNumber = 1251;
    await Tools<OffersEntity>.AddDb(diroffers, connectionString);
}
catch { }

try
{
    Log.Information($"Работаем с ShareDescriptionEntity");
    Tools<ShareDescriptionEntity>.EncodingPageNumber = 1251;
    await Tools<ShareDescriptionEntity>.AddDb(dirsharedescription, connectionString);
}
catch { }

try
{
    Log.Information($"Работаем с SharesEntity");
    Tools<SharesEntity>.EncodingPageNumber = 1251;
    await Tools<SharesEntity>.AddDb(dirshares, connectionString);
}
catch { }
