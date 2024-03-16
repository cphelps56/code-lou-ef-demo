namespace ef_Demo.MVC.Models
{
    public class TestVM
    {
        public int MyProperty { get; set; }
        public int PropertyWeDontNeedToMap { get; set; }
        public static explicit operator Test(TestVM vm)
        {
            return new Test
            {
                MyProperty = vm.MyProperty
            };
        }
    }
}
