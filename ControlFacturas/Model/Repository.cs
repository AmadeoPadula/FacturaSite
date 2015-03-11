using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlFacturas.Model
{
    public class Repository
    {

        public List<Member> GetMembers()
        {
            return new List<Member>()
            {
                new Member
                {
                    MemberId = 1, FirstName = "Jeffrey", MiddleName = "Preston",
                    LastName = "Jorgensen", EmailId = "abc1@xyz.com", NickName = "Jeff Bezos",
                    Age = 50, IsActive = "Active", CreatedDate = new DateTime(2014, 9, 9), Company = "Amazon"
                },
                new Member
                {
                    MemberId = 2, FirstName = "Satyanarayana", MiddleName = "",
                    LastName = "Nadella", EmailId = "abc2@xyz.com", NickName = "Satya Nadella",
                    Age = 46, IsActive = "Active", CreatedDate = new DateTime(2014, 9, 9), Company = "Microsoft"
                },
                new Member
                {
                    MemberId = 3, FirstName = "Adele", MiddleName = "Laurie Blue",
                    LastName = "Adkins", EmailId = "abc3@xyz.com", NickName = "Adele",
                    Age = 26, IsActive = "Active", CreatedDate = new DateTime(2014, 9, 9), Company = "Singer"
                },
                new Member
                {
                    MemberId = 4, FirstName = "David", MiddleName = "Robert Joseph",
                    LastName = "Beckham", EmailId = "abc4@xyz.com", NickName = "Beckham",
                    Age = 39, IsActive = "Inactive", CreatedDate = new DateTime(2014, 9, 9), Company = "Soccer Player"
                }
            };
        }
    }
}