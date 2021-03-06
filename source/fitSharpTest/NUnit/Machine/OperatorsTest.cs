﻿using fitSharp.Machine.Engine;
using fitSharp.Machine.Model;
using NUnit.Framework;

namespace fitSharp.Test.NUnit.Machine {
    [TestFixture] public class OperatorsTest {

        [Test] public void FindsDefaultOperator() {
            var operators = new Operators<string, Processor<string>>();
            operators.Add(new DefaultCreate());
            var result = operators.FindOperator<CreateOperator<string>>(new [] {"test", null});
            Assert.AreEqual(typeof(DefaultCreate), result.GetType());
        }

        class DefaultCreate: Operator<string, Processor<string>>, CreateOperator<string> {
            public bool CanCreate(string memberName, Tree<string> parameters) {
                return true;
            }

            public TypedValue Create(string memberName, Tree<string> parameters) {
                return TypedValue.Void;
            }
        }

    }
}
