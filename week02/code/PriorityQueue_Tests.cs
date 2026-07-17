using Microsoft.VisualStudio.TestTools.UnitTesting;

//TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities: low1, high5, medium3
    // Expected Result: Dequeue returns them in priority order: high, medium, low
    // Defects Found: Original code skipped the last item in the loop offbyone and never
    // removed items from the list, so it returned the same value repeatedly.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("medium", 3);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("medium", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items tied at the same priority first, second, plus a lower one (third)
    // Expected Result: On a tie, the item closer to the front enqueued first comes out first
    // Defect Found: Original code used >= instead of >, so on a tie it kept overwriting with the
    // later item, returning "second" before "first" instead of respecting FIFO order for ties.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);
        priorityQueue.Enqueue("third", 1);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());
    }

    [TestMethod]

    //Scenario: Call Dequeue on a queue that has nothing in it
    //Expected Result: Throws InvalidOperationException with message The queue is empty.
    //Defects Found: None - this behavior already worked correctly in the original code.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message));
        }
    }


}