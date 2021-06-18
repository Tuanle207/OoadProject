using NUnit.Framework;

namespace OoadProject.DataTests.Helpers
{
    public class AssertHelper
    {
        public static void AreEqualByJson(object expected, object actual)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var expectedJson = serializer.Serialize(expected);
            var actualJson = serializer.Serialize(actual);
            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}
