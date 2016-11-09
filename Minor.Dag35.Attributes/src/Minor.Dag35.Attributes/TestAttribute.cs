using System;

namespace Minor.Dag35.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TestAttribute : Attribute
    {
        private readonly object[] _inputArgs;
        private object _output;
        private string _expectedException;

        public object[] Input { get { return _inputArgs; } }
        public object Output { get { return _output; } set { _output = value; } }
        public string ExpectedException { get { return _expectedException; } set { _expectedException = value; } }

        public TestAttribute(params object[] input)
        {
            _inputArgs = input;
        }
    }
}
