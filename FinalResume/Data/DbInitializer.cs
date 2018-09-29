using FinalResume.Models;
using System;
using System.Linq;

namespace FinalResume.Data
{
    public static class DbInitializer
    {

        public static void Initialize(ResumeContext context)
        {
            context.Database.EnsureCreated();
            // Look for any applicants
            if (!context.applicant.Any())
            {

                var applicants = new applicant[]
                {
                new applicant {FirstName="Carson",LastName="Alexander",City="ABQ", State="NM", Phone="505-933-9799", Email="ninedogs@gmail.com", WebAddress="kellycockrell.net" }
    //            new applicant {FirstName="Johnson",LastName="Joan",City="ABQ", State="NM", Phone="505-933-9799", Email="ninedogs@gmail.com", WebAddress="kellycockrell.net"},
    //            new applicant {FirstName="Raphael",LastName="Lobato",City="ABQ", State="NM", Phone="505-933-9799", Email="ninedogs@gmail.com", WebAddress="kellycockrell.net"},
    //            new applicant {FirstName="Elsa",LastName="Castillo",City="ABQ", State="NM", Phone="505-933-9799", Email="ninedogs@gmail.com", WebAddress="kellycockrell.net"},
    //            new applicant {FirstName="Cassiano",LastName="de Oliveira",City="ABQ", State="NM", Phone="505-933-9799", Email="ninedogs@gmail.com", WebAddress="kellycockrell.net"},
    //            new applicant {FirstName="Brendaleigh",LastName="Lobato",City="ABQ", State="NM", Phone="505-933-9799", Email="ninedogs@gmail.com", WebAddress="kellycockrell.net"},
    };
                foreach (applicant a in applicants)
                {
                    context.applicant.Add(a);
                }
                context.SaveChanges();
            }





            if (!context.education.Any())
            {
                var education = new education[]
                {
                    new education {degreeType = "Bachelors", subject = "Fine Arts", institution = "University of New Mexico", city = "Albuquerque", state = "NM", gradDate = "May 1994",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID },
                    new education {degreeType = "Bachelors", subject = "Electrical Engineering", institution = "University of Texas", city = "Austin", state = "NM", gradDate = "May 1994",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID },
                    new education {degreeType = "Masters", subject = "Physics", institution = "Boston College", city = "Boston", state = "MA", gradDate = "May 2016",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID },
                    //new education {degreeType = "PhD", subject = "Sociology", institution = "Harvard University", city = "Cambridge", state = "MA", gradDate = "December 2010",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID },
                    //new education {degreeType = "PhD", subject = "Nuclear Engineering", institution = "Imperial College", city = "London", state = "UK", gradDate = "May 1989",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID },
                    //new education {degreeType = "Associates", subject = "Business Administration", institution = "Santa Fe Community College", city = "Santa Fe", state = "NM", gradDate = "May 2018",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID },
                    //new education {degreeType = "Bachelors", subject = "Biology", institution = "University of Colorado", city = "Boulder", state = "CO", gradDate = "December 1994",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID }


                };
                foreach (education e in education)
                {
                    context.education.Add(e);
                }
                context.SaveChanges();

            }

            if (!context.references.Any())
            {
                var references = new references[]
            {
           new references {firstName= "Barack", lastName = "Obama", companyName = "Former President of the United States", mailingAddress = "P.O. Box 91000", city="Washington DC", state="",  emailAddress= "barack@gmail.com", phone = "212-444-5555", applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID },
           new references {firstName= "Vladimir", lastName = "Putin", companyName = "President and DIctator of Russia", mailingAddress = "P.O. Box 666661", city="Moscow", state="Russia",  emailAddress= "Vlad@gmail.com", phone = "33-433-4424-09090",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID },
           new references {firstName= "Barack", lastName = "Obama", companyName = "Former President of the United States", mailingAddress = "P.O. Box 91000", city="Washington DC", state="",  emailAddress= "barack@gmail.com", phone = "212-444-5555",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID },
           //new references {firstName= "Barack", lastName = "Obama", companyName = "Former President of the United States", mailingAddress = "P.O. Box 91000", city="Washington DC", state="",  emailAddress= "barack@gmail.com", phone = "212-444-5555" },
           //new references {firstName= "Barack", lastName = "Obama", companyName = "Former President of the United States", mailingAddress = "P.O. Box 91000", city="Washington DC", state="",  emailAddress= "barack@gmail.com", phone = "212-444-5555" },
           //new references {firstName= "Barack", lastName = "Obama", companyName = "Former President of the United States", mailingAddress = "P.O. Box 91000", city="Washington DC", state="",  emailAddress= "barack@gmail.com", phone = "212-444-5555" }

           };

                foreach (references r in references)
                {
                    context.references.Add(r);
                }
                context.SaveChanges();
            }
            if (!context.skills.Any())
            {
                var skills = new skills[]
                    {
            new skills {skillName = "Javascript", experienceLevel = "Advanced", yearsUsed = "3", applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID},
            new skills {skillName = "Adobe Photoshop", experienceLevel = "Expert", yearsUsed = "10",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID},
            new skills {skillName = "Adobe Illustrator", experienceLevel = "Advanced", yearsUsed = "8",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID},
            new skills {skillName = "C#", experienceLevel = "Novice", yearsUsed = "1",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID},
            new skills {skillName = "HTML/CSS", experienceLevel = "Expert", yearsUsed = "10",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID},
            new skills {skillName = "Microsoft Office", experienceLevel = "Advanced", yearsUsed = "20",applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID}


                    };
                foreach (skills s in skills)
                {
                    context.skills.Add(s);


                }
                context.SaveChanges();

            }




            if (!context.experience.Any())
            {
                var experience = new Experience[]
                {
                               new Experience {jobName = "Internship Coordinator and Graphic Designer",  placeWorked = "University of New Mexico", city="Albuquerque", state = "NM", startDate = "June 2015", endDate= "present", applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID},
                               new Experience {jobName = "Teacher of Computer Science and Technology", placeWorked = "The Meadows School", city="Las Vegas", state = "NV", startDate = "August 2013", endDate= "June 2015", applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID},
                               new Experience {jobName = "Director of Technology", placeWorked = "Steamboat Mountain School", city="Steamboat Springs", state = "CO", startDate = "June 2012", endDate= "July 2013", applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID },
                               new Experience {jobName = "Technology Lab Coordinator", placeWorked = "Rowland Hall-St. Mark's School", city="Salt Lake City", state = "UT", startDate = "August 2007", endDate= "June 2012", applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID },
                               new Experience {jobName = "Web and UX Designer", placeWorked = "University of Arkansas", city="Fayetteville", state = "AR", startDate = "November 2006", endDate= "August 2007", applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID },
                               new Experience {jobName = "Marketing Advertising Executive", placeWorked = "Lovely County Citizen", city="Eureka Springs", state = "AR", startDate = "Jan 2005", endDate= "October 2006", applicantID = context.applicant.FirstOrDefault(y => y.FirstName == "Carson").ID}

                };
                foreach (Experience e in experience)
                {
                    context.experience.Add(e);
                }
                context.SaveChanges();
            }
            if (!context.duties.Any())
            {
                var duty = new duties[]
                {
                    new duties {summary = "• Coordinates mentoring and internship program under a grant from the National Science Foundation.", experienceID = context.experience.FirstOrDefault(y => y.placeWorked == "University of New Mexico").ID  },
                    new duties {summary =  "• Organizes and expedites mentoring events and meetings with faculty and students.", experienceID = context.experience.FirstOrDefault(y => y.placeWorked == "University of New Mexico").ID  },
                    new duties {summary = "• Advises and mentors students in meaningful development of careers. ", experienceID = context.experience.FirstOrDefault(y => y.placeWorked == "University of New Mexico" ).ID   },
                    new duties {summary = "• Conceptualizes and designs advertising campaigns for School of Engineering.", experienceID = context.experience.FirstOrDefault(y =>y.placeWorked == "The Meadows School").ID   },
                    new duties {summary = "• Photographs students, faculty, and departmental events, to be used for publication", experienceID = context.experience.FirstOrDefault(y => y.placeWorked == "The Meadows School" ).ID  },
                    new duties {summary = "• Conceptualized, designed, and taught computer science and technology curriculum to students in a project-based environment at rigorous private middle school.", experienceID = context.experience.FirstOrDefault(y => y.placeWorked == "The Meadows School").ID },
                    new duties {summary = "• Oversaw entire technology department for an independent boarding school,grades 9-12.", experienceID = context.experience.FirstOrDefault(y =>y.placeWorked == "Steamboat Mountain School").ID },
                    new duties {summary = "• Configured and administered firewall, wireless network, and Active Directory Server." , experienceID = context.experience.FirstOrDefault(y => y.placeWorked == "Steamboat Mountain School").ID },
                    new duties {summary =  "• Oversaw budget, recommended to and consulted with Head of School or purchases.", experienceID = context.experience.FirstOrDefault(y => y.placeWorked == "Steamboat Mountain School").ID  },
                    new duties {summary =  "• Taught graphic design; advised and supervised students in the creation of theschool yearbook.", experienceID = context.experience.FirstOrDefault(y => y.placeWorked == "Rowland Hall-St. Mark's School").ID },
                    new duties {summary = "• Managed the scheduling, maintenance, and security of computer labs.", experienceID = context.experience.FirstOrDefault(y => y.placeWorked == "Rowland Hall-St. Mark's School").ID },
                    new duties  {summary =  "• Recommended hardware, software and learning resources to teachers.", experienceID = context.experience.FirstOrDefault(y => y.placeWorked == "Rowland Hall-St. Mark's School").ID },
                    new duties {summary = "• First responder for end - user and technical support to faculty and students.", experienceID = context.experience.FirstOrDefault(y => y.placeWorked == "Rowland Hall-St. Mark's School").ID }

                    };
                foreach (duties d in duty)
                {
                    context.duties.Add(d);
                }
                context.SaveChanges();

            }
        }
            }
        }
  



    
        
    






