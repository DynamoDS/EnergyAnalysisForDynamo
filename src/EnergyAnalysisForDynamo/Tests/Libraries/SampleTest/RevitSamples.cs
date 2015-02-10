﻿using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using NUnit.Framework;
using RevitServices.Persistence;
using RTF.Framework;

namespace RevitSampleTests
{
    [TestFixture]
    public class RevitSamples
    {
        [SetUp]
        public void Setup()
        {
            //startup logic executed before every test
        }

        [TearDown]
        public void Shutdown()
        {
            //shutdown logic executed after every test
        }

        [Test]
        public void CanCreateAReferencePoint()
        {
            using (var t = new Transaction(DocumentManager.Instance.CurrentDBDocument))
            {
                if (t.Start("Test one.") == TransactionStatus.Started)
                {
                    //create a reference point
                    var pt = DocumentManager.Instance.CurrentDBDocument.FamilyCreate.NewReferencePoint(new XYZ(5, 5, 5));

                    if (t.Commit() != TransactionStatus.Committed)
                    {
                        t.RollBack();
                    }
                }
                else
                {
                    throw new Exception("Transaction could not be started.");
                }
            }

            //verify that the point was created
            var collector = new FilteredElementCollector(DocumentManager.Instance.CurrentDBDocument);
            collector.OfClass(typeof(ReferencePoint));

            Assert.AreEqual(1, collector.ToElements().Count);
        }

        [Test]
        [TestModel(@"./bricks.rfa")]
        public void ModelHasTheCorrectNumberOfBricks()
        {
            var fec = new FilteredElementCollector(DocumentManager.Instance.CurrentDBDocument);
            fec.OfClass(typeof(FamilyInstance));

            var bricks = fec.ToElements()
                .Cast<FamilyInstance>()
                .Where(fi => fi.Symbol.Family.Name == "brick");

            Assert.AreEqual(bricks.Count(), 4);
        }

        [Test]
        public void TestThree()
        {
            //this will pass.
            Assert.AreEqual(0, 0);
        }

        [Test]
        public void LeaveAMessage()
        {
            Assert.Pass("This test passed. Hooray!");
        }

        /// <summary>
        /// Opens and activates a new model, and closes the old model.
        /// </summary>
        private void SwapCurrentModel(string modelPath)
        {
            Document initialDoc = DocumentManager.Instance.CurrentUIDocument.Document;
            DocumentManager.Instance.CurrentUIApplication.OpenAndActivateDocument(modelPath);
            initialDoc.Close(false);
        }
    }
}
