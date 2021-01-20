using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Core.Entities;

namespace Core.Database
{
    public class SeedData
    {
        public static void SeedDatabase(AppDbContext dbContext)
        {
            var MySHA256 = SHA256.Create();

            List<ApplicationUser> Users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = Guid.Parse("4C6E72B2-87DC-4CDC-A855-A72498DC067B"),
                    Email ="john@doe.com",
                    UserName ="John Doe",
                    ProfilePicture = new Image
                    {
                        Id = Guid.NewGuid(),
                        Url = "/images/profile_m.png"
                    },
                    Gender = Gender.Male,
                    PasswordHash = Encoding.UTF8.GetString(MySHA256.ComputeHash(Encoding.UTF8.GetBytes("Qwerty1@" + "MySecret"))),
                },
                new ApplicationUser
                {
                    Id = Guid.Parse("65444AF4-841A-4B73-BE7F-C49CB7069C4B"),
                    Email ="jane@doe.com",
                    UserName ="Jane Doe",
                    ProfilePicture = new Image
                    {
                        Id = Guid.NewGuid(),
                        Url = "/images/profile_m.png"
                    },
                    Gender = Gender.Female,
                    PasswordHash = Encoding.UTF8.GetString(MySHA256.ComputeHash(Encoding.UTF8.GetBytes("Qwerty1@" + "MySecret"))),
                }
            };

            if (!dbContext.Users.Any())
            {
                dbContext.Users.AddRange(Users);
                dbContext.SaveChanges();

            }

            List<Place> places = new List<Place>
            {
                new Place
                {
                    Id = Guid.Parse("94EAB6AD-8062-4CE2-A982-3CA495652363"),
                    Name ="Wells Cathedral",
                    ShortDescription ="Climb the spiral staircase to walk in the footsteps of Cathedral masons tours...",
                    LongDescription ="Wells Cathedral is a combined bascule and suspension bridge in London, built between 1886 and 1894. The bridge crosses the River Thames close to the Tower of London and has become an iconic symbol of London. As a result, it is sometimes confused with London Bridge, about half a mile (0.8 km) upstream. Tower Bridge is one of five London bridges owned and maintained by the Bridge House Estates, a charitable trust overseen by the City of London Corporation. It is the only one of the trust's bridges not to connect the City of London directly to the Southwark bank, as its northern landfall is in Tower Hamlets.",
                    Image = new Image
                    {
                        Id = Guid.Parse("D00D120A-D563-442F-9ECE-358ED0B88ED7"),
                        Url = "https://i.ibb.co/q5qFy4S/exterior-in-late-evening.jpg"
                    }

                },
                new Place
                {
                    Id = Guid.Parse("D4A1AFB0-1968-41FD-9646-AEFFCB21E736"),
                    Name ="Coleton Fishare",
                    ShortDescription ="A property consisting of a garden and a house in the Arts",
                    LongDescription ="Coleton Fishare is the nickname for the Great Bell of the striking clock at the north end of the Palace of Westminster in London[1] and is usually extended to refer to both the clock and the clock tower.[2][3] The official Name of the tower in which Big Ben is located was originally the Clock Tower, but it was renamed Elizabeth Tower in 2012 to mark the Diamond Jubilee of Elizabeth II.The tower was designed by Augustus Pugin in a neo-Gothic style. When completed in 1859, its clock was the largest and most accurate four-faced striking and chiming clock in the world.[4] The tower stands 315 feet (96 m) tall, and the climb from ground level to the belfry is 334 steps. Its base is square, measuring 39 feet (12 m) on each side. Dials of the clock are 23 feet (7.0 m) in diameter. On 31 May 2009, celebrations were held to mark the tower's 150th anniversary.",
                    Image = new Image
                    {
                        Id = Guid.Parse("E3C7F467-9115-41BD-BA2B-10EC79609D55"),
                        Url = "https://i.ibb.co/kgYGqtc/coleton-fishacre.jpg"
                    }
                },
                new Place
                {
                    Id = Guid.Parse("CA6FE982-3379-4B47-93ED-4923FF893ECD"),
                    Name ="Sherborne Abbey",
                    ShortDescription ="A Church of England church in Sherborne in the English county...",
                    LongDescription ="Sherborne Abbey is a combined bascule and suspension bridge in London, built between 1886 and 1894. The bridge crosses the River Thames close to the Tower of London and has become an iconic symbol of London. As a result, it is sometimes confused with London Bridge, about half a mile (0.8 km) upstream. Tower Bridge is one of five London bridges owned and maintained by the Bridge House Estates, a charitable trust overseen by the City of London Corporation. It is the only one of the trust's bridges not to connect the City of London directly to the Southwark bank, as its northern landfall is in Tower Hamlets.",
                    Image = new Image
                    {
                        Id = Guid.Parse("C6136239-8852-419B-8399-1D88749B880D"),
                        Url = "https://i.ibb.co/k82gBf6/the-abbey.jpg"
                    }
                },
                new Place
                {
                    Id = Guid.Parse("55B399EA-8264-4A18-AACE-3ED413B715EA"),
                    Name ="Nothe Fort",
                    ShortDescription ="This 19th century Fort includes a museum highlighting coastal...",
                    LongDescription ="North Fort is a combined bascule and suspension bridge in London, built between 1886 and 1894. The bridge crosses the River Thames close to the Tower of London and has become an iconic symbol of London. As a result, it is sometimes confused with London Bridge, about half a mile (0.8 km) upstream. Tower Bridge is one of five London bridges owned and maintained by the Bridge House Estates, a charitable trust overseen by the City of London Corporation. It is the only one of the trust's bridges not to connect the City of London directly to the Southwark bank, as its northern landfall is in Tower Hamlets.",
                    Image = new Image
                    {
                        Id = Guid.Parse("D2CC58D2-2554-4CEE-91B3-CAFF50EFF78B"),
                        Url = "https://i.ibb.co/J7WM5x8/aeriel-view.jpg"
                    }
                },
                new Place
                {
                    Id = Guid.Parse("9b4f5735-c83d-493b-8785-5231888e2ba2"),
                    Name ="The Close",
                    ShortDescription ="Nice and quiet so you can come and sit for a while away from the bustle of ...",
                    LongDescription ="Wells Cathedral is a combined bascule and suspension bridge in London, built between 1886 and 1894. The bridge crosses the River Thames close to the Tower of London and has become an iconic symbol of London. As a result, it is sometimes confused with London Bridge, about half a mile (0.8 km) upstream. Tower Bridge is one of five London bridges owned and maintained by the Bridge House Estates, a charitable trust overseen by the City of London Corporation. It is the only one of the trust's bridges not to connect the City of London directly to the Southwark bank, as its northern landfall is in Tower Hamlets.",
                    Image = new Image
                    {
                        Id = Guid.Parse("2385b931-f10f-44d0-a3b3-067b474ab095"),
                        Url = "https://i.ibb.co/2SVQmdZ/enjoy-the-setting.jpg"
                    }

                },
                new Place
                {
                    Id = Guid.Parse("874f891c-12f9-4124-8b15-460576a05af5"),
                    Name ="Dunster Castle",
                    ShortDescription ="The castle lies on the top of a steep hill called the Tor, and has been fortified",
                    LongDescription ="Wells Cathedral is a combined bascule and suspension bridge in London, built between 1886 and 1894. The bridge crosses the River Thames close to the Tower of London and has become an iconic symbol of London. As a result, it is sometimes confused with London Bridge, about half a mile (0.8 km) upstream. Tower Bridge is one of five London bridges owned and maintained by the Bridge House Estates, a charitable trust overseen by the City of London Corporation. It is the only one of the trust's bridges not to connect the City of London directly to the Southwark bank, as its northern landfall is in Tower Hamlets.",
                    Image = new Image
                    {
                        Id = Guid.Parse("909949c6-5879-47be-a5d3-1db3c14f217f"),
                        Url = "https://i.ibb.co/nccLT6h/the-castle-as-seen-from.jpg"
                    }

                },
                new Place
                {
                    Id = Guid.Parse("b4260314-05c3-4a74-9a9e-a8b2e8e8c629"),
                    Name ="Chalice Well",
                    ShortDescription ="A well situated at the foot of Glastonbury Tor in the county of Somerset",
                    LongDescription ="Wells Cathedral is a combined bascule and suspension bridge in London, built between 1886 and 1894. The bridge crosses the River Thames close to the Tower of London and has become an iconic symbol of London. As a result, it is sometimes confused with London Bridge, about half a mile (0.8 km) upstream. Tower Bridge is one of five London bridges owned and maintained by the Bridge House Estates, a charitable trust overseen by the City of London Corporation. It is the only one of the trust's bridges not to connect the City of London directly to the Southwark bank, as its northern landfall is in Tower Hamlets.",
                    Image = new Image
                    {
                        Id = Guid.Parse("cdcabc4e-545a-4b23-b10e-75152ce7e96b"),
                        Url = "https://i.ibb.co/XCrXLt1/dsc-0275-largejpg.jpg"
                    }

                },
                new Place
                {
                    Id = Guid.Parse("2e319f11-512e-49c4-818d-45d0914074f7"),
                    Name ="Chambercombe Manor",
                    ShortDescription ="Coleton Fishacre is a property consisting of a garden and a house in...",
                    LongDescription ="Wells Cathedral is a combined bascule and suspension bridge in London, built between 1886 and 1894. The bridge crosses the River Thames close to the Tower of London and has become an iconic symbol of London. As a result, it is sometimes confused with London Bridge, about half a mile (0.8 km) upstream. Tower Bridge is one of five London bridges owned and maintained by the Bridge House Estates, a charitable trust overseen by the City of London Corporation. It is the only one of the trust's bridges not to connect the City of London directly to the Southwark bank, as its northern landfall is in Tower Hamlets.",
                    Image = new Image
                    {
                        Id = Guid.Parse("e2c60e90-9ad4-44ad-a476-a4c1c39d653b"),
                        Url = "https://i.ibb.co/GTMg8Hs/chambercombe-manor-complex.jpg"
                    }

                },
            };

            if (!dbContext.Places.Any())
            {
                dbContext.Places.AddRange(places);
                dbContext.SaveChanges();
            }

            List<Review> reviews = new List<Review>
            {
                new Review
                {
                    Id = Guid.Parse("302AC5EF-BAAF-4697-8612-4E78F4B10F67"),
                    Title="Awesome Place!!!",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Image = new Image
                    {
                        Id = Guid.NewGuid(),
                        Url = "http://www.apexcartage.com/wp-content/uploads/revslider/rev_slider_example/placeholder-red.png"

                    },
                    Rating = Enums.Rating.Rate_3,
                    ReviewedOn = new DateTime(2020,11,12),
                    PlaceId = Guid.Parse("94EAB6AD-8062-4CE2-A982-3CA495652363"),
                    ReviewerId = Guid.Parse("4C6E72B2-87DC-4CDC-A855-A72498DC067B"),
                },
                new Review
                {
                    Id = Guid.Parse("04536519-6BC2-4057-B888-849F131BC58D"),
                    Title="Will visit again !!!",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Image = new Image
                    {
                        Id = Guid.NewGuid(),
                        Url = "http://www.apexcartage.com/wp-content/uploads/revslider/rev_slider_example/placeholder-red.png"

                    },
                    Rating = Enums.Rating.Rate_3,
                    ReviewedOn = new DateTime(2020,11,12),
                    PlaceId = Guid.Parse("94EAB6AD-8062-4CE2-A982-3CA495652363"),
                    ReviewerId = Guid.Parse("65444AF4-841A-4B73-BE7F-C49CB7069C4B"),
                },
                new Review
                {
                    Id = Guid.Parse("F8B09215-71C6-46B1-8C8A-ACC7AEC8B207"),
                    Title="Breathtaking !!!",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Image = new Image
                    {
                        Id = Guid.NewGuid(),
                        Url = "https://i.ibb.co/RCHnShQ/arno-smit-i-I72r3g-Sw-WY-unsplash.jpg"

                    },
                    Rating = Enums.Rating.Rate_3,
                    ReviewedOn = new DateTime(2020,12,25),
                    PlaceId = Guid.Parse("D4A1AFB0-1968-41FD-9646-AEFFCB21E736"),
                    ReviewerId = Guid.Parse("4C6E72B2-87DC-4CDC-A855-A72498DC067B")
                },new Review
                {
                    Id = Guid.Parse("48ECD590-DE11-4A3D-A9ED-57D956A5924E"),
                    Title="Must Visit",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Image = new Image
                    {
                        Id = Guid.NewGuid(),
                        Url = "https://i.ibb.co/yqWQBTW/mathis-jrdl-o7-Be-B6-LE04-E-unsplash.jpg"

                    },
                    Rating = Enums.Rating.Rate_3,
                    ReviewedOn = new DateTime(2020,12,29),
                    PlaceId = Guid.Parse("D4A1AFB0-1968-41FD-9646-AEFFCB21E736"),
                    ReviewerId = Guid.Parse("65444AF4-841A-4B73-BE7F-C49CB7069C4B")
                },
                new Review
                {
                    Id = Guid.Parse("e60ac3b6-f63d-43e5-8b68-8f88635f6e49"),
                    Title="Beautiful Place!!!",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Image = new Image
                    {
                        Id = Guid.NewGuid(),
                        Url = "https://i.ibb.co/D7rVnf1/marta-bibi-N-l-K5xh-XIug-unsplash.jpg"

                    },
                    Rating = Enums.Rating.Rate_4,
                    ReviewedOn = new DateTime(2020,11,12),
                    PlaceId = Guid.Parse("D4A1AFB0-1968-41FD-9646-AEFFCB21E736"),
                    ReviewerId = Guid.Parse("4C6E72B2-87DC-4CDC-A855-A72498DC067B"),
                },
                new Review
                {
                    Id = Guid.Parse("622a053f-d3ab-4165-b60e-26bc32dffdf1"),
                    Title="Nice and quite place !!!",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Image = new Image
                    {
                        Id = Guid.NewGuid(),
                        Url = "https://i.ibb.co/Z8SZLYD/ignacio-correia-1-yycyo-MT6g-unsplash.jpg"

                    },
                    Rating = Enums.Rating.Rate_5,
                    ReviewedOn = new DateTime(2020,11,12),
                    PlaceId = Guid.Parse("D4A1AFB0-1968-41FD-9646-AEFFCB21E736"),
                    ReviewerId = Guid.Parse("65444AF4-841A-4B73-BE7F-C49CB7069C4B"),
                },
            };

            if (!dbContext.Reviews.Any())
            {
                dbContext.Reviews.AddRange(reviews);
                dbContext.SaveChanges();
            }

            List<Question> qsList = new List<Question>
            {
                new Question
                {
                    Id = Guid.NewGuid(),
                    PlaceId = Guid.Parse("D4A1AFB0-1968-41FD-9646-AEFFCB21E736"),
                    OwnerId = Guid.Parse("65444AF4-841A-4B73-BE7F-C49CB7069C4B"),
                    QuestionBody = "Is it a good place to visit with children?",
                    CreatedOn = new DateTime(2020, 10, 15),
                    Answers = new List<Answer> {},
                    Likes = new List<QuestionLikes> {}
                },
                new Question
                {
                    Id = Guid.NewGuid(),
                    PlaceId = Guid.Parse("D4A1AFB0-1968-41FD-9646-AEFFCB21E736"),
                    OwnerId = Guid.Parse("4C6E72B2-87DC-4CDC-A855-A72498DC067B"),
                    QuestionBody = "How much is the ticket for entrance?",
                    CreatedOn = new DateTime(2020, 11, 23),
                    Answers = new List<Answer> {},
                    Likes = new List<QuestionLikes> {}
                },
                new Question
                {
                    Id = Guid.NewGuid(),
                    PlaceId = Guid.Parse("D4A1AFB0-1968-41FD-9646-AEFFCB21E736"),
                    OwnerId = Guid.Parse("4C6E72B2-87DC-4CDC-A855-A72498DC067B"),
                    QuestionBody = "At what time is it opening?",
                    CreatedOn = new DateTime(2020, 12, 28),
                    Answers = new List<Answer> {},
                    Likes = new List<QuestionLikes> {}
                }
            };

            if (!dbContext.Questions.Any())
            {
                dbContext.Questions.AddRange(qsList);
                dbContext.SaveChanges();
            }

            var trainStations = new List<TrainStation>{
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Abbey Wood",
                    Code="ABW"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Atherstone",
                    Code="ATH"
                },new TrainStation

                {
                    Id = Guid.NewGuid(),
                    Name="Bardon Mill",
                    Code="BLL"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Builth Road",
                    Code="BHR"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Dalwhinnie",
                    Code="DLW"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Dunbar",
                    Code="DUN"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Eskbank",
                    Code="EKB"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Fairwater",
                    Code="FRW"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Fort William",
                    Code="FTW"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Isleworth",
                    Code="ISL"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Ivybridge",
                    Code="IVY"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Kirkwood",
                    Code="KWD"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Manchester Airport",
                    Code="MCO"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Maryland",
                    Code="MYL"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Mottingham",
                    Code="MTG"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Tadworth",
                    Code="TAD"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Turkey Street",
                    Code="TUR"
                },
                new TrainStation
                {
                    Id = Guid.NewGuid(),
                    Name="Warminster",
                    Code="WMN"
                }
            };

            if (!dbContext.Stations.Any())
            {
                dbContext.Stations.AddRange(trainStations);
                dbContext.SaveChanges();
            }

            var train = new List<Train>{
                new Train
                {
                    Id=Guid.NewGuid(),
                    Name = "Devon Express",
                    ClassAPrice = 50,
                    ClassBPrice = 100,
                    ClassCPrice = 200,
                },
                new Train
                {
                    Id=Guid.NewGuid(),
                    Name = "East Anglian",
                    ClassAPrice = 50,
                    ClassBPrice = 100,
                    ClassCPrice = 200,
                },
                new Train
                {
                    Id=Guid.NewGuid(),
                    Name = "Enterprise",
                    ClassAPrice = 50,
                    ClassBPrice = 100,
                    ClassCPrice = 200,
                },
                new Train
                {
                    Id=Guid.NewGuid(),
                    Name = "Flying Scotsman",
                    ClassAPrice = 50,
                    ClassBPrice = 100,
                    ClassCPrice = 200,

                },
                new Train
                {
                    Id=Guid.NewGuid(),
                    Name = "Master Cutler",
                    ClassAPrice = 50,
                    ClassBPrice = 100,
                    ClassCPrice = 200,

                },
                new Train
                {
                    Id=Guid.NewGuid(),
                    Name = "Mayflower",
                    ClassAPrice = 50,
                    ClassBPrice = 100,
                    ClassCPrice = 200,

                },
                new Train
                {
                    Id=Guid.NewGuid(),
                    Name = "The Merchant Venturer",
                    ClassAPrice = 50,
                    ClassBPrice = 100,
                    ClassCPrice = 200,

                },
                new Train
                {
                    Id=Guid.NewGuid(),
                    Name = "Night Riviera",
                    ClassAPrice = 50,
                    ClassBPrice = 100,
                    ClassCPrice = 200,

                },
            };

            if (!dbContext.Trains.Any())
            {
                dbContext.Trains.AddRange(train);
                dbContext.SaveChanges();
            }

            
            var quizzes = new List<Quiz>{
                new Quiz
                {
                    Id=Guid.Parse("f2a7051e-f91d-4efb-8bee-c26b474a80a0"),
                    PlaceId = Guid.Parse("D4A1AFB0-1968-41FD-9646-AEFFCB21E736"),
                },
                
            };

            var quizQuestions = new List<QuizQuestion>
                    {
                        new QuizQuestion
                        {
                            Id = Guid.Parse("f4c9ca01-2c55-4231-8356-23acfca1d3c2"),
                            Title = "Coleton Fishacre is a property consisting of a garden and a house in the Arts and Craft ?",
                            Time = 10,
                            Points = 10,
                            QuizId = Guid.Parse("f2a7051e-f91d-4efb-8bee-c26b474a80a0"),
                            AnswerOptions = "True, False, Not Aware",
                            CorrectAnswer = "True"
                            

                        },
                         new QuizQuestion
                        {
                            Id = Guid.Parse("c127a075-35d8-43c2-89b2-fa5aeb674a06"),
                            Title = "In which county is Coleton Fishacre located?",
                            Time = 10,
                            Points = 10,
                            QuizId = Guid.Parse("f2a7051e-f91d-4efb-8bee-c26b474a80a0"),
                            AnswerOptions = "Middlesex, Somerset, Devon, Sussex",
                            CorrectAnswer = "Devon"

                        },
                         new QuizQuestion
                        {
                            Id = Guid.NewGuid(),
                            Title = "Who owns Coleton Fishacre?",
                            Time = 10,
                            Points = 10,
                            QuizId = Guid.Parse("f2a7051e-f91d-4efb-8bee-c26b474a80a0"),
                            AnswerOptions = "Heritage Trust Network, The Landmark Trust, The Vivat Trust, National Trust",
                            CorrectAnswer = "National Trust"


                        },
                         new QuizQuestion
                        {
                            Id = Guid.NewGuid(),
                            Title = "Which of the following can be seen around Coleton Fishacre?",
                            Time = 10,
                            Points = 10,
                            QuizId = Guid.Parse("f2a7051e-f91d-4efb-8bee-c26b474a80a0"),
                            AnswerOptions = "River, Sea, Pond, Forest",
                            CorrectAnswer = "Sea"

                        },
                         new QuizQuestion
                        {
                            Id = Guid.NewGuid(),
                            Title = "Coleton Fishacre is a property consisting of a garden and a house in the Arts and Crafts style?",
                            Time = 15,
                            Points = 10,
                            QuizId = Guid.Parse("f2a7051e-f91d-4efb-8bee-c26b474a80a0"),
                            AnswerOptions = "True, False, Not Aware",
                            CorrectAnswer = "True"

                        }
                    };


            
            if (!dbContext.Quizzes.Any())
            {
                dbContext.Quizzes.AddRange(quizzes);
                dbContext.SaveChanges();

                dbContext.QuizQuestions.AddRange(quizQuestions);
                dbContext.SaveChanges();

            }
            

        }
    }
}
            