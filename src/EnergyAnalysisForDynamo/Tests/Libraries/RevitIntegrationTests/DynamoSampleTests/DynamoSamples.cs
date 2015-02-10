using System.IO;
using System.Linq;
using Autodesk.Revit.DB;
using NUnit.Framework;
using RevitServices.Persistence;
using RTF.Framework;

namespace DynamoSampleTests
{
    [TestFixture]
    public class DynamoSamples : SystemTest
    {

        [Test]
        [TestModel(@".\empty.rfa")]
        public void ReferencePoint()
        {
            string testPath = Path.Combine(workingDirectory, @".\ReferencePoint.dyn");
            ViewModel.OpenCommand.Execute(testPath);

            Assert.AreEqual(3, ViewModel.Model.CurrentWorkspace.Nodes.Count);

            RunCurrentModel();
        }
    }
}
