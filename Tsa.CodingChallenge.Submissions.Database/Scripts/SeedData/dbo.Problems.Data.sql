SET IDENTITY_INSERT dbo.Problems ON

MERGE dbo.Problems AS [target]
USING ( VALUES (1, 'FIRST_DUPLICATE_NUMBER', 'First Duplicate Number', '<p>Given an array <code class="w3-codespan">array</code> that contains only numbers in the range from <code class="w3-codespan">1</code> to <code class="w3-codespan">array.length</code>, find the first duplicate number for which the second occurrence has the minimal index. In other words, if there are more than <code class="w3-codespan">1</code> duplicated numbers, return the number for which the second occurrence has a smaller index than the second occurrence of the other number does. If there are no such elements, return <code class="w3-codespan">-1</code>.</p>

<h4>Example</h4>
<ul>
    <li>For <code class="w3-codespan">array = [2, 3, 3, 1, 5, 2]</code>, the output should be <code class="w3-codespan">firstDuplicate(array) = 3</code>. There are <code class="w3-codespan">2</code> duplicates: numbers <code class="w3-codespan">2</code> and <code class="w3-codespan">3</code>. The second occurrence of <code class="w3-codespan">3</code> has a smaller index than than second occurrence of <code class="w3-codespan">2</code> does, so the answer is <code class="w3-codespan">3</code>.</li>
    <li>For <code class="w3-codespan">array = [2, 4, 3, 5, 1]</code>, the output should be <code class="w3-codespan">FirstDuplicate(array) = -1</code>.</li>
</ul>

<h4>Input/Output</h4>
<ul>
    <li><strong>[Input]</strong> Array of integers</li>
    <li>
        <strong>[Constraints]</strong><br />
        <code class="w3-codespan">1 &le; array.length &le; 10^4</code>,<br />
        <code class="w3-codespan">1 &le; array[i] &le; array.length</code>
    </li>
    <li><strong>[Output]</strong> The element in a that occurs in the array more than once and has the minimal index for its second occurrence. If there are no such elements, return <code class="w3-codespan">-1</code>.</li>
</ul>'),
               (2, 'LETTER_PATH', 'Letter Path', '<p>You will be given a <code class="w3-codespan">2D</code> matrix of English lower case letters. Your mission today is to find the longest path that following these rules below.</p>

<ul>
    <li>The path can only be straight line or form a 90 degree corner</li>
    <li>In each step, the next letter must be different from the current letter</li>
    <li>The path cannot cut itself or form a loop path</li>
    <li>If there are more than one longest path, pick the highest one</li>
</ul>

<h4>Example</h4>
<p>For</p>
<pre><code>letterMap = 
a   b   c
d   e   f
g   h   i</code></pre>

<p>the output should be <code class="w3-codespan">letterPath(letterMap) = "ihgdefcba"</code>.</p>

<p>In this example, we have several longest paths: <code class="w3-codespan">abcfihgde</code>, <code class="w3-codespan">adghifcbe</code>, <code class="w3-codespan">edghifcba</code>, etc. The highest one is the final answer <code class="w3-codespan">ihgdefcba</code>.</p>

<h4>Input/Output</h4>
<ul>
    <li><strong>[Input]</strong> Two dimensional array of strings
    <li>
        <strong>[Constraints]</strong><br />
        <code class="w3-codespan">0 &le; letterMap.length &le; 5</code><br />
        <code class="w3-codespan">0 &le; letterMap[i].length = letterMap[i + 1].length &le; 5</code><br />
        <code class="w3-codespan">letterMap[i][j].length = 1 and contains only a-z</code><br />
    </li>
    <li><strong>[Output]</strong> The string that is the longest path</li>
</ul>'),
               (3, 'CATCH_THE_EGGS', 'Catch the Eggs', '<p>You just got a job as the egg-catcher in a poorly-designed egg factory.</p>

<p>
    The chickens are all lined up in a row on one side of the factory.<br />
    Each chicken has a conveyor belt under it that is delivering dropped eggs to you.<br />
    If you are at the end of a conveyor belt when the egg arrives, you catch it.<br />
    If not, the egg falls onto the floor and you do not catch it.
</p>

<p>You begin your shift at the conveyor belt for chicken #1.</p>

<p>During a "turn":</p>
<ul>
    <li>Eggs travel down the conveyor belts 1 positional unit.</li>
    <li>You can move <code class="w3-codespan">1</code> position to the left, <code class="w3-codespan">1</code> position to the right, or stay where you are.</li>
</ul>

<p>Given the input. Return the maximum number of eggs that you could possibly catch during your shift.</p>

<h4>Example</h4>
<p>For <code class="w3-codespan">numberOfChickens = 3, conveyorLength = 1</code> and <code class="w3-codespan">eggs = [[1, 3], [2], [3] ]</code>, the output should be <code class="w3-codespan">CatchTheEggs(numberOfChickens, conveyorLength, eggs) = 3</code>.</p>

<p>Turn 1:</p>
<pre><code>---------------
Chickens  1 2 3
Conveyor  o   o
You       U
---------------</code></pre>

<p>
    Stay by <code class="w3-codespan">chicken1</code> and catch <code class="w3-codespan">1</code> egg.<br />
    You could move to <code class="w3-codespan">chicken2</code>, but there is no egg there.<br />
    You cannot reach chicken <code class="w3-codespan">3</code> because you can ONLY MOVE <code class="w3-codespan">1</code> POSITION TO the LEFT OR RIGHT.
</p>

<p>Turn 2:</p>
<pre><code>---------------
Chickens  1 2 3
Conveyor    o
You         U
---------------</code></pre>

<p>Move to <code class="w3-codespan">chicken2</code> AND CATCH <code class="w3-codespan">1</code> egg.</p>

<p>Turn 3:</p>
<pre><code>---------------
Chickens  1 2 3
Conveyor      o
You           U
---------------</code></pre>

<p>Move to <code class="w3-codespan">chicken3</code> AND CATCH <code class="w3-codespan">1</code> egg.

<p>So, the number OF caught eggs IS <code class="w3-codespan">3</code>.

<h4>Input/Output</h4>
<ul>
    <li><strong>[Input]</strong> INTEGER, the number OF chickens</li>
    <li>
        <strong>[Constraint]</strong><br />
        <code class="w3-codespan">0 &le; numberOfChickens &le; 500</code>
    </li>
    <li><strong>[Input]</strong> Integer, the conveyor length</li>
    <li>
        <strong>[Constraint]</strong><br />
        <code class="w3-codespan">0 &lt; conveyorLength &le; 100</code>
    </li>
    <li><strong>[Input]</strong> Array of integers, the position of the eggs</li>
    <li>
        <strong>[Constraint]</strong><br />
        <code class="w3-codespan">0 &le; eggs.length &le; 500</code>
    </li>
</ul>'))
               AS [source] (Id, Identifier, [Name], [Description])
ON [target].Id = [source].Id
WHEN MATCHED AND [target].Identifier != [source].Identifier
             OR  [target].[Name] != [source].[Name]
             OR  [target].[Description] != [source].[Description]
    THEN UPDATE SET	[target].Identifier = [source].Identifier,
                    [target].[Name] = [source].[Name],
                    [target].[Description] = [source].[Description]
WHEN NOT MATCHED
    THEN	INSERT (Id, Identifier, [Name], [Description])
            VALUES (Id, Identifier, [Name], [Description]);

SET IDENTITY_INSERT dbo.Problems OFF