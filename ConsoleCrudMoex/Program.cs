// See https://aka.ms/new-console-template for more information
using ConsoleCrudMoex;
using Microsoft.Extensions.Configuration;
using MoexEntity;

// Custom for entity postgresql
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false);

var config = builder.Build();

var connectionString = config["postgres:connection"];

var dirbonds = config["moex:dirbonds"];
var dirbonddescription = config["moex:dirbonddescription"];
var direurobonddescription = config["moex:direurobonddescription"];

var dircoupons = config["moex:dircoupons"];

var diramortization = config["moex:diramortization"];

var diroffers = config["moex:diroffers"];

var dirsharedescription = config["moex:dirsharedescription"];
var dirshares = config["moex:dirshares"];

// Add Copages to project
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

try
{
    Tools<BondEntity>.EncodingPageNumber = 1251;
    await Tools<BondEntity>.AddDb(dirbonds, connectionString);
}
catch { }

try
{
    Tools<BondDescriptionEntity>.EncodingPageNumber = 1251;
    await Tools<BondDescriptionEntity>.AddDb(dirbonddescription, connectionString);
}
catch { }

try
{
    Tools<EurobondDescriptionEntity>.EncodingPageNumber = 1251;
    await Tools<EurobondDescriptionEntity>.AddDb(direurobonddescription, connectionString);
}
catch { }

try
{
    Tools<CouponEntity>.EncodingPageNumber = 1251;
    await Tools<CouponEntity>.AddDb(dircoupons, connectionString);
}
catch { }

try
{
    Tools<AmortizationEntity>.EncodingPageNumber = 1251;
    await Tools<AmortizationEntity>.AddDb(diramortization, connectionString);
}
catch { }

try
{
    Tools<OffersEntity>.EncodingPageNumber = 1251;
    await Tools<OffersEntity>.AddDb(diroffers, connectionString);
}
catch { }

try
{
    Tools<ShareDescriptionEntity>.EncodingPageNumber = 1251;
    await Tools<ShareDescriptionEntity>.AddDb(dirsharedescription, connectionString);
}
catch { }

try
{
    Tools<SharesEntity>.EncodingPageNumber = 1251;
    await Tools<SharesEntity>.AddDb(dirshares, connectionString);
}
catch { }
