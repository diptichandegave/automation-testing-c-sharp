using UIAutomationCSharpProject.PageMethods;

namespace UIAutomationCSharpProject.Tests
{
    [TestClass]
    public class WebTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            BaseMethods bm  = new BaseMethods();
            bm.NavigateAndVerifyDashboardPage();
            Thread.Sleep(2000);
            bm.navigateToHealthInsuranceTabAndVerify();
        }
    }
}