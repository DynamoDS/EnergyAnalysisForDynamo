using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using RevitTestServices;
using RTF.Framework;

namespace Tests
{
    [TestFixture]
    public class RTFtest1 : RevitSystemTestBase
    {
        //[Test, TestModel(@".\EnergyAnalysisForDynamo_ex1_simpleRevitMass.rvt")]
        [Test]
        public void HelloWorld()
        {
            //OpenSampleDefinition(@"EnergyAnalysisForDynamo_ex1b_CreateEnergyModelAndSetSurfaceParams.dyn");

            Assert.Pass();
        }
    }
}
