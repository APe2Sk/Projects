// See https://aka.ms/new-console-template for more information


using BranchTask;

int findDepth(Branch branch)
{
    if (branch.branches.Count == 0)
        return 1;

    int maxdepth = 1;
    foreach (Branch br in branch.branches)
        maxdepth = Math.Max(maxdepth, findDepth(br));

    return maxdepth + 1;
}


// Test 1, should return debth of 4
#region Sample 1
    var branch = new Branch();

    var branch1 = new Branch();

    branch1.branches.Add(new Branch());
    branch1.branches.Add(new Branch());
    branch1.branches.Add(new Branch());

    var branch2 = new Branch();
    branch2.branches.Add(new Branch());
    branch1.branches.Add(branch2);



    branch.branches.Add(branch1);

    Console.WriteLine($"The depth of the first test is {findDepth(branch)}.");
#endregion


Branch createBranch(int numChild)
{
    Branch branch = new Branch();

    for (int i = 0; i < numChild; i++)
        branch.branches.Add(new Branch());

    return branch;
}

// Test 2, should return debth of 5
#region Sample 2 
var rootBranch = new Branch();

    var rootBranch1 = createBranch(1);

    var rootBranch2 = createBranch(2);

    rootBranch2.branches[0].branches.Add(new Branch());

    rootBranch2.branches.Add(createBranch(2));

    rootBranch2.branches[2].branches[0].branches.Add(new Branch());

    rootBranch.branches.Add(rootBranch1);
    rootBranch.branches.Add(rootBranch2);

    Console.WriteLine($"The depth of the second test is {findDepth(rootBranch)}.");
#endregion