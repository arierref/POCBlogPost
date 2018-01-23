using System;
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
    }
}
