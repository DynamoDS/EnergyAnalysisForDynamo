using System.IO;
using System.Linq;

using Autodesk.Revit.DB;
using NUnit.Framework;
using RevitServices.Persistence;
using RTF.Framework;
using RevitSystemTests;

namespace RevitIntegrationTests
{
    [TestFixture]
    public class ReferencePointTests : SystemTest
    {

        [Test]
        [TestModel(@".\empty.rfa")]
        public void ReferencePoint()
        {
            string testPath = Path.Combine(workingDirectory, @".\ReferencePoint\ReferencePoint.dyn");
            ViewModel.OpenCommand.Execute(testPath);

            Assert.AreEqual(3, ViewModel.Model.CurrentWorkspace.Nodes.Count);

            RunCurrentModel();
            //ViewModel.Model.RunExpression();
        }
    }
}
