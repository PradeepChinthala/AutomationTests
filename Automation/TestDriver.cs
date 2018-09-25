using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation
{
    public enum Status
    {
        Passed,Failed,Ready
    }
    
    public interface ITestDriver
    {        
        string TestIdentifier { get; set; }
        string TestDescription { get; set; }
        string Environment { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        TimeSpan Duration { get; set; }
        Status Status { get; set; }
        Exception TestException { get; set; }
        Status RunStep(Action action,IStepInfo stepinfo);
        Status RunStep<T>(Action<T> action, T Parameter, IStepInfo stepinfo);
        Status RunStep<T>(Action<T,T> action, T Parameter1,T Parameter2, IStepInfo stepinfo);
        Status RunStep<T1,T2>(Action<T1,T2> action, T1 Parameter1, T2 Parameter2, IStepInfo stepinfo);
    }

    public class TestDriver : ITestDriver
    {
        private static TestDriver _instance;
        private TestContext _testContext;
        private DriverLogger _logger;

        private IList<IStepInfo> _testSteps = new List<IStepInfo>() { };

        public Exception TestException { get ; set ; }
        public string TestIdentifier { get  ; set  ; }
        public string TestDescription { get  ; set  ; }
        public string Environment { get; set; }
        public DateTime StartTime { get  ; set  ; }
        public DateTime EndTime { get  ; set  ; }
        public TimeSpan Duration { get  ; set  ; }
        public Status Status { get  ; set  ; }

        public static TestDriver Instance
        {
            get
            {
                return _instance;
            }
        }

        public TestContext TestContext
        {
            get
            {
                return _testContext;
            }            
        }

        //Constructor
        public TestDriver(TestContext testContext)
        {
            _testContext = testContext;
            TestIdentifier = testContext.Test.Name;
            TestDescription = testContext.Test.FullName;
            Status = Status.Ready;

        }

        public static void Initialize(TestContext testContext)
        {
            _instance = new TestDriver(testContext);
        }

        public Status RunStep(Action action, IStepInfo stepInfo)
        {
            try
            {
                action();
                stepInfo.Status = Status.Passed;
            }
            catch (Exception ex)
            {
                HandleException(ex, stepInfo);
            }
            return stepInfo.Status;
        }

        public Status RunStep<T>(Action<T> action, T Parameter, IStepInfo stepInfo)
        {
            try
            {
                action(Parameter);
                stepInfo.Status = Status.Passed;
            }
            catch (Exception ex)
            {
                HandleException(ex, stepInfo);
            }
            return stepInfo.Status;
        }

        public Status RunStep<T>(Action<T, T> action, T Parameter1, T Parameter2, IStepInfo stepInfo)
        {
            try
            {
                action(Parameter1, Parameter2);
                stepInfo.Status = Status.Passed;
            }
            catch(Exception ex)
            {
                HandleException(ex, stepInfo);
            }
            return stepInfo.Status;
        }

        public Status RunStep<T1, T2>(Action<T1, T2> action, T1 Parameter1, T2 Parameter2, IStepInfo stepInfo)
        {
            try
            {
                action(Parameter1, Parameter2);
                stepInfo.Status = Status.Passed;
            }
            catch (Exception ex)
            {
                HandleException(ex, stepInfo);
            }
            return stepInfo.Status;
        }

        private void HandleException(Exception ex, IStepInfo stepInfo)
        {
            stepInfo.Status = Status.Failed;
            stepInfo.StepException = ex;
        }

    }

    // holds the TestStep information 
    public interface IStepInfo
    {
        string Descrption { get; set; }
        Status Status { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        TimeSpan Duration { get; set; }
        Exception StepException { get; set; }

    }
    public class StepInfo : IStepInfo
    {
        public string Descrption { get; set; }
        public Status Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public Exception StepException { get; set; }


        public StepInfo()
        {
            StepInit();
        }
        public StepInfo(string description)
        {
            Descrption = description;
        }

        private void StepInit()
        {
            Descrption = "Step Description not defiend";
            Status = Status.Ready;
        }
    }

    public class DriverLogger
    {
        public virtual void BeginStep()
        {
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("[step]");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
