using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POCBlogPost.Tests
{
    [TestClass]
    public class RulesTest
    {
        [TestMethod]
        public void EditTitle_BringOnlyTheLastWord()
        {
            //Arrange
            ListPost Post = new ListPost();
            Post.title = "fg sdfg s sgfhsdgh sdf sdgh s LastWord";
            string expectedresult = "LastWord";

            //Act
            string actualresult = Rules.EditTitle(Post.title);

            //Assert
            Assert.AreEqual(expectedresult, actualresult);
        }

        [TestMethod]
        public void EditBody_BringFirst15CharacteresAndTheLastWord()
        {
            //Arrange
            ListPost Post = new ListPost();
            Post.body = "svteyste rt vye tr  er ch er her LastWord2";
            string expectedresult = "svteyste rt vye LastWord2";

            //Act
            string actualresult = Rules.EditBody(Post.body);

            //Assert
            Assert.AreEqual(expectedresult, actualresult);
        }

        [TestMethod]
        public void GetFileName_GenerateAFileWithAFormatUserid_yyyyMMdd_hhmmss()
        {
            //Arrange
            string userId = "1";
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var dateAsString = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            string expectedresult = mydocpath + $"\\1_{dateAsString}.txt";

            //Act
            string actualresult = Rules.GetFileName(userId);

            //Assert
            Assert.AreEqual(expectedresult, actualresult);
        }

        [TestMethod]
        public void Distinct_RemovePostsWithEvenId()
        {
            //Arrange
            var Posts = new List<ListPost>();
            var count = 0;

            Posts.Add(new ListPost() { id = 1, userId = 1, body = "sdfg sg sd", title = "fasd f" });
            Posts.Add(new ListPost() { id = 1, userId = 1, body = "sdfg sg sd", title = "fasd f" });
            Posts.Add(new ListPost() { id = 2, userId = 2, body = "vdfgfgsdf", title = "ffffff" });
            Posts.Add(new ListPost() { id = 3, userId = 3, body = "sdfg sg sd", title = "fasd f" });
            Posts.Add(new ListPost() { id = 1, userId = 1, body = "sdfg sg sd", title = "fasd f" });
            Posts.Add(new ListPost() { id = 4, userId = 1, body = "sdfg sg sd", title = "fasd f" });
            Posts.Add(new ListPost() { id = 5, userId = 1, body = "sdfg sg sd", title = "fasd f" });

            var distinct = Posts.GroupBy(s => s.id).Select(s => s.First());

            foreach(var x in distinct)  
            {
                count++;
            };
            
            //var newPost = Posts;

            //Assert
            Assert.IsTrue(count==5);
        }
    }
}
