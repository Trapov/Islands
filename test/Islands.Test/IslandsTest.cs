using NUnit.Framework;

namespace Islands.Test
{
    public class IslandsTest
    {
        [TestCase(TestName = "1 islands")]
        public void Test2Islands()
        {
            
            var arr = new[,] 
            {
                {0,1,0},
                {1,0,0},
                {0,0,0}
            };
            
            var solver = new IslandsSolverBulder()
                .SetArray(arr)
                .Build();

            Assert.NotNull(solver);
            Assert.AreEqual(1, solver.Solve());
        }

        [TestCase(TestName = "3 islands")]
        public void Test3Islands()
        {
            
            var arr = new[,] 
            {
                {0,0,0,0,1,1},
                {0,1,0,0,1,0},
                {0,1,1,0,1,1},
                {1,1,1,0,0,0},
                {0,0,0,1,1,0},
                {1,0,0,1,1,0},
            };
            
            var solver = new IslandsSolverBulder()
                .SetArray(arr)
                .Build();

            Assert.NotNull(solver);
            Assert.AreEqual(3, solver.Solve());
        }

        [TestCase(TestName = "4 islands")]
        public void Test4Islands()
        {

            var arr = new[,]
            {
                {0,0,0,0,1,1},
                {0,1,0,0,1,0},
                {0,1,1,0,1,1},
                {1,1,0,0,0,0},
                {0,0,0,1,1,0},
                {1,0,0,1,1,0},
            };

            var solver = new IslandsSolverBulder()
                .SetArray(arr)
                .Build();

            Assert.NotNull(solver);
            Assert.AreEqual(4, solver.Solve());
        }

        [TestCase(TestName = "5 islands")]
        public void Test5Islands()
        {

            var arr = new[,]
            {
                {1,0,0,0,1,1},
                {0,0,0,0,1,0},
                {0,1,1,0,1,1},
                {1,1,0,0,0,0},
                {0,0,0,1,1,0},
                {1,0,0,1,1,0}
            };

            var solver = new IslandsSolverBulder()
                .SetArray(arr)
                .Build();

            Assert.NotNull(solver);
            Assert.AreEqual(5, solver.Solve());
        }

        [TestCase(TestName = "6 islands")]
        public void Test6Islands()
        {

            var arr = new[,]
            {
                {1,0,0,0,1,1},
                {0,0,0,0,1,0},
                {0,1,1,0,1,1},
                {1,1,0,0,0,0},
                {0,0,0,1,0,0},
                {1,0,0,1,0,1}
            };

            var solver = new IslandsSolverBulder()
                .SetArray(arr)
                .Build();

            Assert.NotNull(solver);
            Assert.AreEqual(6, solver.Solve());
        }

        [TestCase(TestName = "6 islands with bigger map")]
        public void Test6IslandsWithBiggerMap()
        {

            var arr = new[,]
            {
                {1,0,0,0,1,1,0},
                {0,0,0,0,1,0,0},
                {0,1,1,0,1,1,0},
                {1,1,0,0,0,0,0},
                {0,0,0,1,0,0,0},
                {1,0,0,1,0,1,0}
            };

            var solver = new IslandsSolverBulder()
                .SetArray(arr)
                .Build();

            Assert.NotNull(solver);
            Assert.AreEqual(6, solver.Solve());
        }
    }
}