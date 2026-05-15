using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: This test covers the basic case where items are added with different priorities and the
    // queue should return the highest-priority value first.
    // Expected Result: The item with the largest priority number should come out first.
    // Defect(s) Found: Dequeue was skipping the last item during its search, so the real highest priority
    // could be missed. The search loop now checks the whole list.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: This checks the tie case. If two items have the same top priority, the one that got into
    // the queue first should still come out first.
    // Expected Result: Equal priorities should keep FIFO behavior.
    // Defect(s) Found: The original comparison moved to the later matching item, which broke FIFO ties.
    // Using a strict greater-than comparison keeps the earlier item in front.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 4);
        priorityQueue.Enqueue("Second", 4);
        priorityQueue.Enqueue("Third", 2);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: This test makes sure removing one item actually changes the queue, so a second dequeue can
    // move on to the next best choice instead of returning the same value again.
    // Expected Result: After the first removal, the next dequeue should return the next highest remaining item.
    // Defect(s) Found: The value was being returned without being removed from the list. Removing the item
    // from the queue fixed the repeated result.
    public void TestPriorityQueue_RemovesItemAfterDequeue()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();

        Assert.AreEqual("B", first);
        Assert.AreEqual("C", second);
    }

    [TestMethod]
    // Scenario: This covers the empty queue case so the class throws the required exception instead of
    // returning a value or crashing with the wrong message.
    // Expected Result: InvalidOperationException with the exact required message.
    // Defect(s) Found: No bug showed up here once the test was added, but it is important coverage because
    // the assignment requires the exact exception message.
    public void TestPriorityQueue_EmptyQueueThrows()
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
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}