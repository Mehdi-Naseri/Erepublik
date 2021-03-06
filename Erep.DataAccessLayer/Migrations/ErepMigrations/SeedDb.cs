﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//جهت فعال سازی و دسترسی به بخش اکانت
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using Erep.DomainClasses.Models.Identity;

//جهت ارتباط با پایگاه داده
using Erep.DataLayer.DataContext;
using Erep.DataLayer.Migrations.ErepMigrations;
using Erep.DomainClasses.Models;
using System.Data.Entity;

namespace Erep.DataLayer.Migrations.ErepMigrations
{
    public class SeedDb
    {

        public void CreateAdminUserAndRole()
        {
            //Initialzie Admin user and Password
            IdentityContext IdentityContext1 = new IdentityContext();
            UserManager<ApplicationUser> UserManager1 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
            //Create User "Admin" if it is not existed.
            if (UserManager1.FindByName("Admin") == null)
            {
                var user = new ApplicationUser() { UserName = "Admin" };
                UserManager1.Create(user, "Pass#1");
            }
            //Create Role "Admin" if it is not existed.
            RoleManager<IdentityRole> RoleManager1 = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityContext()));
            if (RoleManager1.FindByName("Admin") == null)
            {
                IdentityRole IdentityRole1 = new IdentityRole("Admin");
                RoleManager1.Create(IdentityRole1);
            }
            //Add Admin user to Admin Role
            string IdentityUserId = IdentityContext1.Users.First(x => x.UserName == "Admin").Id;
            UserManager1.AddToRole(IdentityUserId, "Admin");
        }

        public void AddRoles()
        {
            RoleManager<IdentityRole> RoleManager1 = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityContext()));
            string[] RoleNames = { "ScammerAdmin", "ScammerCreator" };
            foreach (string RoleName in RoleNames)
            {
                if (RoleManager1.FindByName(RoleName) == null)
                {
                    IdentityRole IdentityRole1 = new IdentityRole(RoleName);
                    RoleManager1.Create(IdentityRole1);
                }
            }

        }

        public void AddScammers()
        {
            DataContext.ErepContext ErepContext = new ErepContext();
            //Erep.DomainClasses.Models.Scammer Scammer = new Scammer();

            foreach (List<string> listString in ScammersList)
            {
                Scammer scammer = new Scammer() { Name = listString[0], Link = listString[1], ReportedBy = listString[2], Description = listString[3] };
                if (!ErepContext.Scammers.Any(r => r.Link == scammer.Link))
                {
                    ErepContext.Scammers.Add(scammer);
                    ErepContext.SaveChanges();
                }
            }

        }

        private List<List<string>> ScammersList = new List<List<string>>{
            new List<string>{"Bojan933","http://www.erepublik.com/en/citizen/profile/6385383","Admin",""} ,
            new List<string>{"muua1","http://www.erepublik.com/en/citizen/profile/4393680","Admin",""} ,
            new List<string>{"thedarkwolf","http://www.erepublik.com/en/citizen/profile/4498074","Admin",""} ,
            new List<string>{"VasilovskiBG","http://www.erepublik.com/en/citizen/profile/4634363","Admin",""} ,
            new List<string>{"TheWicky","http://www.erepublik.com/en/citizen/profile/4312291","Admin",""},
            new List<string>{"Godfather Corleone","http://www.erepublik.com/en/citizen/profile/3304729","Admin",""} ,
            new List<string>{"Misery7","http://www.erepublik.com/en/citizen/profile/5794487","Admin",""} ,
            new List<string>{"blackwoIf901","http://www.erepublik.com/en/citizen/profile/4800094","Admin",""} ,
            new List<string>{"VanBaster (a.k.a. basat)","http://www.erepublik.com/en/citizen/profile/4537115","Admin",""} ,
            new List<string>{"baxul","http://www.erepublik.com/en/citizen/profile/1520199","Admin",""} ,
            new List<string>{"Birziminium","http://www.erepublik.com/en/citizen/profile/4959616","Admin",""} ,
            new List<string>{"blkc","http://www.erepublik.com/en/citizen/profile/5271729","Admin",""} ,
            new List<string>{"Buharin","http://www.erepublik.com/en/citizen/profile/4839384","Admin",""} ,
            new List<string>{"Burhan11","http://www.erepublik.com/en/citizen/profile/5817715","Admin",""} ,
            new List<string>{"Captain Igor","http://www.erepublik.com/en/citizen/profile/4239389","Admin",""} ,
            new List<string>{"Val3s OBrien","http://www.erepublik.com/en/citizen/profile/1737175","Admin",""} ,
            new List<string>{"Civcije","http://www.erepublik.com/en/citizen/profile/5869958","Admin",""} ,
            new List<string>{"Corps3","http://www.erepublik.com/en/citizen/profile/5731021","Admin",""} ,
            new List<string>{"Sofia1912","http://www.erepublik.com/en/citizen/profile/4281131","Admin",""} ,
            new List<string>{"Crosermk","http://www.erepublik.com/en/citizen/profile/4565948","Admin",""} ,
            new List<string>{"Aexil Kong Junior","http://www.erepublik.com/en/citizen/profile/6325718","Admin",""} ,
            new List<string>{"Dalakas","http://www.erepublik.com/en/citizen/profile/4002681","Admin",""} ,
            new List<string>{"adrian11","http://www.erepublik.com/en/citizen/profile/2037935","Admin",""} ,
            new List<string>{"david nastev","http://www.erepublik.com/en/citizen/profile/5021122","Admin",""} ,
            new List<string>{"death rider","http://www.erepublik.com/en/citizen/profile/1493211","Admin",""} ,
            new List<string>{"deepble","http://www.erepublik.com/en/citizen/profile/2426238","Admin",""} ,
            new List<string>{"Kutluk Bilge Kul Dontbejealous","http://www.erepublik.com/en/citizen/profile/5304155","Admin",""} ,
            new List<string>{"drksd","http://www.erepublik.com/en/citizen/profile/4331199","Admin",""} ,
            new List<string>{"Domagoj123457689","http://www.erepublik.com/en/citizen/profile/5569430","Admin",""} ,
            new List<string>{"dostojevski555","http://www.erepublik.com/en/citizen/profile/6210190","Admin",""} ,
            new List<string>{"Dzoni_filozof","http://www.erepublik.com/en/citizen/profile/1377413","Admin",""} ,
            new List<string>{"webarts","http://www.erepublik.com/en/citizen/profile/1321146","Admin",""} ,
            new List<string>{"ElvisPrist","http://www.erepublik.com/en/citizen/profile/6056254","Admin",""} ,
            new List<string>{"eRussian Ministry Of Culture","http://www.erepublik.com/en/citizen/profile/2144118","Admin","سازمان"} ,
            new List<string>{"eRussian Reserve","http://www.erepublik.com/en/economy/citizen-accounts/1437685","Admin","سازمان"} ,
            new List<string>{"escipion10","http://www.erepublik.com/en/citizen/profile/5147408","Admin",""} ,
            new List<string>{"Fanatic Vu","http://www.erepublik.com/en/citizen/profile/5641570","Admin",""} ,
            new List<string>{"fuzzy0wuzzy","http://www.erepublik.com/en/citizen/profile/4590217","Admin",""} ,
            new List<string>{"Gethrodrak","http://www.erepublik.com/en/citizen/profile/1295271","Admin",""} ,
            new List<string>{"givati187","http://www.erepublik.com/en/citizen/profile/4183927","Admin",""} ,
            new List<string>{"Alexis of Macedonia","http://www.erepublik.com/en/citizen/profile/4559888","Admin",""} ,
            new List<string>{"Camh One","http://www.erepublik.com/en/citizen/profile/3504526","Admin",""} ,
            new List<string>{"hero1andi","http://www.erepublik.com/en/citizen/profile/6106961","Admin",""} ,
            new List<string>{"Uniunea Democrata","http://www.erepublik.com/en/citizen/profile/1931424","Admin",""} ,
            new List<string>{"humulus tank","http://www.erepublik.com/en/citizen/profile/2041054","Admin","سازمان"} ,
            new List<string>{"SnorKky","http://www.erepublik.com/en/citizen/profile/4359524","Admin",""} ,
            new List<string>{"KarateMK","http://www.erepublik.com/en/citizen/profile/5179071","Admin",""} ,
            new List<string>{"KRIMIKO","http://www.erepublik.com/en/citizen/profile/5160508","Admin",""} ,
            new List<string>{"lazcavus","http://www.erepublik.com/en/citizen/profile/3557516","Admin",""} ,
            new List<string>{"Legendary Force eManuela","http://www.erepublik.com/en/citizen/profile/4792742","Admin",""} ,
            new List<string>{"Lentulus Batiatus","http://www.erepublik.com/en/citizen/profile/4011938","Admin",""} ,
            new List<string>{"Ayroh","http://www.erepublik.com/en/citizen/profile/3477610","Admin",""} ,
            new List<string>{"Like a Bo0s","http://www.erepublik.com/en/citizen/profile/6080968","Admin",""} ,
            new List<string>{"lopov93","http://www.erepublik.com/en/citizen/profile/5450160","Admin",""} ,
            new List<string>{"luka1hero","http://www.erepublik.com/en/citizen/profile/6887871","Admin",""} ,
            new List<string>{"Luka3332","http://www.erepublik.com/en/citizen/profile/6978560","Admin",""} ,
            new List<string>{"Macedonia96","http://www.erepublik.com/de/citizen/profile/4326078","Admin",""} ,
            new List<string>{"Macedonian heart","http://www.erepublik.com/en/citizen/profile/3986491","Admin",""} ,
            new List<string>{"MACEDONIAN T REX","http://www.erepublik.com/en/citizen/profile/4778226","Admin",""} ,
            new List<string>{"mahuntanhu","http://www.erepublik.com/en/citizen/profile/3962957","Admin",""} ,
            new List<string>{"StiflerFromAerodrom","http://www.erepublik.com/en/citizen/profile/4203960","Admin",""} ,
            new List<string>{"martink8 JAN","http://www.erepublik.com/en/citizen/profile/4595173","Admin",""} ,
            new List<string>{"Mr DeNNiS","http://www.erepublik.com/en/citizen/profile/4177211","Admin",""} ,
            new List<string>{"Mr Loba Loba","http://www.erepublik.com/en/citizen/profile/6296398","Admin",""} ,
            new List<string>{"Muhomorka","http://www.erepublik.com/en/citizen/profile/4348135","Admin",""} ,
            new List<string>{"BogdanDrac","http://www.erepublik.com/en/citizen/profile/781341","Admin",""} ,
            new List<string>{"niko3005","http://www.erepublik.com/en/citizen/profile/5122744","Admin",""} ,
            new List<string>{"onfodapi","http://www.erepublik.com/en/citizen/profile/4526740","Admin",""} ,
            new List<string>{"OnlyUnKNowN","http://www.erepublik.com/en/citizen/profile/3565543","Admin",""} ,
            new List<string>{"Orchish","http://www.erepublik.com/en/citizen/profile/4012160","Admin",""} ,
            new List<string>{"OverMaximiano","http://www.erepublik.com/en/citizen/profile/5517746","Admin",""} ,
            new List<string>{"PegazisBg","http://www.erepublik.com/en/citizen/profile/4337486","Admin",""} ,
            new List<string>{"The Consigliere","http://www.erepublik.com/en/citizen/profile/1545071","Admin",""} ,
            new List<string>{"Purice","http://www.erepublik.com/en/citizen/profile/1546645","Admin",""} ,
            new List<string>{"MADAFAKA NEY DEMEK","http://www.erepublik.com/en/citizen/profile/4562674","Admin",""} ,
            new List<string>{"Rebv4rw","http://www.erepublik.com/en/citizen/profile/5785068","Admin",""} ,
            new List<string>{"rey tisler","http://www.erepublik.com/en/citizen/profile/2691370","Admin",""} ,
            new List<string>{"Kutluk Bilge Kul reaksyon","http://www.erepublik.com/en/citizen/profile/5257970","Admin",""} ,
            new List<string>{"Schumaher","http://www.erepublik.com/en/citizen/profile/4992334","Admin",""} ,
            new List<string>{"Sectus","http://www.erepublik.com/en/citizen/profile/4181513","Admin",""} ,
            new List<string>{"Black Bess (a.k.a. Seleuk Nikator)","http://www.erepublik.com/en/citizen/profile/4400776","Admin",""} ,
            new List<string>{"Shurupinho","http://www.erepublik.com/en/citizen/profile/5236838","Admin",""} ,
            new List<string>{"Mr. Destroyer","http://www.erepublik.com/en/citizen/profile/4380284","Admin",""} ,
            new List<string>{"Stef40","http://www.erepublik.com/en/citizen/profile/4296648","Admin",""} ,
            new List<string>{"Jack Pott","http://www.erepublik.com/en/citizen/profile/2540626","Admin",""} ,
            new List<string>{"Timy18","http://www.erepublik.com/en/citizen/profile/5019746","Admin",""} ,
            new List<string>{"humulus tank","http://www.erepublik.com/en/economy/citizen-accounts/2041054","Admin",""} ,
            new List<string>{"TurkeyDogu","http://www.erepublik.com/en/citizen/profile/4106812","Admin",""} ,
            new List<string>{"KaradelikNecmi","http://www.erepublik.com/en/citizen/profile/4670331","Admin",""} ,
            new List<string>{"WhiteAngels","http://www.erepublik.com/en/citizen/profile/4298116","Admin",""} ,
            new List<string>{"Vojne","http://www.erepublik.com/en/citizen/profile/4861115","Admin",""} ,
            new List<string>{"micha333","http://www.erepublik.com/en/citizen/profile/4679788","Admin",""} ,
            new List<string>{"wincenzzo","http://www.erepublik.com/en/citizen/profile/4763477","Admin",""} ,
            new List<string>{"WladyslawSzpilman","http://www.erepublik.com/en/citizen/profile/4769365","Admin",""},
            new List<string>{"XyV456","http://www.erepublik.com/en/citizen/profile/5886407","Admin",""},
            new List<string>{"Alexander of Babylon","http://www.erepublik.com/en/citizen/profile/6437641","Admin",""},
            new List<string>{"3v3rything","http://www.erepublik.com/en/citizen/profile/5991562","Admin",""},
            new List<string>{"Mozart 42","http://www.erepublik.com/en/citizen/profile/4892586","Admin",""},
            new List<string>{"surges","http://www.erepublik.com/en/citizen/profile/4837680","Admin",""},
            new List<string>{"Aliien","http://www.erepublik.com/en/citizen/profile/5990288","Admin",""},
            new List<string>{"B34R BIH","http://www.erepublik.com/en/citizen/profile/2463754","Admin",""},
            new List<string>{"BosnaFanatik","http://www.erepublik.com/en/citizen/profile/1886783","Admin",""},
            new List<string>{"bl4ck0uts","http://www.erepublik.com/en/citizen/profile/6739819","Admin",""},
            new List<string>{"croBoyka","http://www.erepublik.com/en/citizen/profile/5771642","Admin",""},
            new List<string>{"luka1hero","http://www.erepublik.com/en/citizen/profile/6887871","Admin",""},
            new List<string>{"Alen9","http://www.erepublik.com/en/citizen/profile/4038897","Admin",""},
            new List<string>{"Alen001","http://www.erepublik.com/en/citizen/profile/4312667","Admin",""},
            new List<string>{"Corps3 SS","http://www.erepublik.com/en/citizen/profile/4195459","Admin",""},
            new List<string>{"Ulroker","http://www.erepublik.com/en/citizen/profile/7088457","Admin",""},
            new List<string>{"Boom3ranG","http://www.erepublik.com/en/citizen/profile/6259809","Admin",""},
            new List<string>{"Crazed03","http://www.erepublik.com/en/citizen/profile/7097579","Admin",""},
            new List<string>{"kuthesh","http://www.erepublik.com/en/citizen/profile/1040001","Admin",""},
            new List<string>{"nikac123","http://www.erepublik.com/en/citizen/profile/4298719","Admin",""},
            new List<string>{"Naix11","http://www.erepublik.com/en/citizen/profile/5093246","Admin",""},
            new List<string>{"Kutluk Bilge Kul Veled I Sina","http://www.erepublik.com/en/citizen/profile/4381438","Admin",""},
            new List<string>{"Spermofrlacot","http://www.erepublik.com/en/citizen/profile/4420196","Admin",""},
            new List<string>{"Niski Kartel 1970","http://www.erepublik.com/en/citizen/profile/5620790","Admin",""},
            new List<string>{"Sapadak","http://www.erepublik.com/en/citizen/profile/4637546","Admin",""},
            new List<string>{"Ayame Crocodile","http://www.erepublik.com/en/citizen/profile/1630767","Admin",""},
            new List<string>{"TheMarko","http://www.erepublik.com/en/citizen/profile/4331194","Admin",""},
            new List<string>{"Ariona","http://www.erepublik.com/en/citizen/profile/6348633","Admin",""},
            new List<string>{"Kutluk Bilge Kul Jack4dam","http://www.erepublik.com/en/citizen/profile/5401113","Admin",""},
            new List<string>{"Red Halcon","http://www.erepublik.com/en/citizen/profile/6584141","Admin",""},
            new List<string>{"XxXF3NiXxX","http://www.erepublik.com/en/citizen/profile/6936523","Admin",""},
            new List<string>{"Lucky.Luciano","http://www.erepublik.com/hr/citizen/profile/7341172","Admin",""},
            new List<string>{"Jakel Javak","http://www.erepublik.com/hr/citizen/profile/6747432","Admin",""},
            new List<string>{"xkaosx","http://www.erepublik.com/en/citizen/profile/3090428","Admin",""},
            new List<string>{"XperTT","http://www.erepublik.com/tr/citizen/profile/7128203","Admin",""},
            new List<string>{"Kutluk Bilge Kul Grant","http://www.erepublik.com/hr/citizen/profile/3968301","Admin",""} ,
            new List<string>{"Dalmatae","http://www.erepublik.com/en/citizen/profile/6979309","Admin",""} ,
            new List<string>{"Laqusta1","http://www.erepublik.com/en/citizen/profile/7624673","Admin",""} ,
            new List<string>{"Donis the OC","http://www.erepublik.com/en/citizen/profile/2284373","Admin",""} ,
            new List<string>{"oibbe","http://www.erepublik.com/en/citizen/profile/7562022","Admin",""} ,
            new List<string>{"sven112234","http://www.erepublik.com/en/citizen/profile/6330337","Admin",""} ,
            new List<string>{"Illiricus","http://www.erepublik.com/en/citizen/profile/7628829","Admin",""} ,
            new List<string>{"Igoreckkkk","http://www.erepublik.com/en/citizen/profile/6731772","Admin",""} ,
            new List<string>{"Zeus1133","http://www.erepublik.com/en/citizen/profile/5302538","Admin",""} ,
            new List<string>{"ALLEZ LE LOSC","http://www.erepublik.com/en/citizen/profile/5369313","Admin",""} ,
            new List<string>{"Qemali","http://www.erepublik.com/en/citizen/profile/7250664","Admin",""} ,
            new List<string>{"Super.Soldier","http://www.erepublik.com/en/citizen/profile/5531842","Admin",""} ,
            new List<string>{"ermal85","http://www.erepublik.com/en/citizen/profile/5420388","Admin",""} ,
            new List<string>{"cro_armagedon","http://www.erepublik.com/en/citizen/profile/3572627","Admin",""} ,
            new List<string>{"Hanibal LA","http://www.erepublik.com/en/citizen/profile/4560179","Admin",""},
            new List<string>{"Milos Miskovic","http://www.erepublik.com/en/citizen/profile/1419250","Admin",""},
            new List<string>{"Al1970Capone","http://www.erepublik.com/en/citizen/profile/2098567","Admin",""},
            new List<string>{"Niski Kartel 1970","http://www.erepublik.com/en/citizen/profile/5620790","Admin",""},
            new List<string>{"OSVETNIK87","http://www.erepublik.com/en/citizen/profile/5112076","Admin",""},
            new List<string>{"e-kladionica Kladguba","http://www.erepublikcommunity.com","Admin","سایت خارجی"},
            new List<string>{"Arhivator Cvarkov (a.k.a. Serbian Citizen)","http://www.erepublik.com/en/citizen/profile/2142236","Admin",""},
            new List<string>{"pancakepunisher","http://www.erepublik.com/en/citizen/profile/2650943","Admin",""},
            new List<string>{"Jamal 2","http://www.erepublik.com/en/citizen/profile/6840893","Admin",""},
            new List<string>{"PhoenixOne","http://www.erepublik.com/sr/citizen/profile/7327927","Admin",""},
            new List<string>{"DrKisprdilov","http://www.erepublik.com/en/citizen/profile/6658366","Admin",""},
            new List<string>{"Krisfor","http://www.erepublik.com/en/citizen/profile/3941226","Admin",""},
            new List<string>{"Svetais Ugunskrusts","http://www.erepublik.com/en/citizen/profile/6585036","Admin",""},
            new List<string>{"Kapten Klitoris","http://www.erepublik.com/en/citizen/profile/3775622","Admin",""},
            new List<string>{"Duh Voina","http://www.erepublik.com/en/citizen/profile/2030853","Admin",""} ,
            new List<string>{"Naboal","http://www.erepublik.com/en/citizen/profile/3521822","Admin",""} ,
            new List<string>{"Kutluk Bilge Kul Typeous","http://www.erepublik.com/en/citizen/profile/6609254","Admin",""} ,
            new List<string>{"Lord SherlockHolmes","http://www.erepublik.com/es/citizen/profile/4617280","Admin",""} ,
            new List<string>{"Latvian Soldier (Kursants Ivancovs)","http://www.erepublik.com/en/citizen/profile/5119756","Admin",""} ,
            new List<string>{"Bosnia n (SerbianPhanom)","http://www.erepublik.com/en/citizen/profile/6541730","Admin",""} ,
            new List<string>{"Monnonus","http://www.erepublik.com/en/citizen/profile/6675825","Admin",""} ,
            new List<string>{"Le0nldas","http://www.erepublik.com/en/citizen/profile/4546063","Admin",""} ,
            new List<string>{"Numbeo","http://www.erepublik.com/en/citizen/profile/3988613","Admin",""} ,
            new List<string>{"It is my fault...sorry. (a.k.a. Rider of the Pale Horse)","http://www.erepublik.com/en/citizen/profile/4020472","Admin",""} ,
            new List<string>{"Duke of Hazard","http://www.erepublik.com/en/citizen/profile/3526571","Admin",""} ,
            new List<string>{"Arhiepiskop Dugopoljski","http://www.erepublik.com/en/citizen/profile/5436032","Admin",""} ,
            new List<string>{"Knight of Gjirokastra","http://www.erepublik.com/en/citizen/profile/8217431","Admin",""} };
    }
}
