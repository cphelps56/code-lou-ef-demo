using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ef_Demo.MVC.Models
{
    public static class TestVMExtenstions
    {
        public static Test ToTestClass(this TestVM vm)
        {
            return new Test
            {
                MyProperty = vm.MyProperty
            };
        }
    }
}
