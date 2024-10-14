INSERT INTO "Classes" VALUES
(1, 'CCP65KTPM'),
(2, 'CCP65CNTT');

INSERT INTO "Users" VALUES (1, 'Phuc', '12345', 0, false),
                           (2, 'Yen', '12345', 0, false),
                           (3, 'Ninh', '12345', 0, false),
                           (4, 'Khanh', '12345', 0, false),
                           (5, 'Thu', '12345', 0, false),
                           (6, 'Tung', '12345', 0, false);

INSERT INTO "Problems"("ProblemId", "Title", "TestCode", "Description", "Difficulty", "Solution", "TemplateCode") VALUES
(1, 'Two Sum',
 ARRAY ['Python', 'JavaScript'],
 $$Given an array of integers `nums` and an integer `target`, *return indices of the two numbers such that they add up to `target`.*

You may assume that each input would have ***exactly one solution***, and you may not use the same element twice.

You can return the answer in any order.

<br>

**Example 1:**

    Input: nums = [2,7,11,15], target = 9
    Output: [0,1]
    Output: Because nums[0] + nums[1] == 9, we return [0, 1].

**Example 2:**

    Input: nums = [3,2,4], target = 6
    Output: [1,2]

**Example 3:**

    Input: nums = [3,3], target = 6
    Output: [0,1]

<br>

**Constraints:**

* `2 <= nums.length <= 104`
* `-109 <= nums[i] <= 109`
* `-109 <= target <= 109`
* **Only one valid answer exists.**

<br>

**Follow-up:** Can you come up with an algorithm that is less than <code>O(n<sup>^</sup>2)</code> time complexity?$$,
 1, true,
 ARRAY ['Python', 'JavaScript']);

INSERT INTO "Problems"("ProblemId", "Title", "TestCode", "Description", "Difficulty", "Solution", "TemplateCode") VALUES
(2, 'Add Two Numbers',
 ARRAY ['Python', 'JavaScript'],
 $$You are given two **non-empty** linked lists representing two non-negative integers. The digits are stored in **reverse order**, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

<br>

**Example 1:**

![](https://assets.leetcode.com/uploads/2020/10/02/addtwonumber1.jpg)

    Input: l1 = [2,4,3], l2 = [5,6,4]
    Output: [7,0,8]
    Explanation: 342 + 465 = 807.

**Example 2:**

    Input: l1 = [0], l2 = [0]
    Output: [0]

**Example 3:**

    Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
    Output: [8,9,9,9,0,0,0,1]

<br>

**Constraints:**

* The number of nodes in each linked list is in the range `[1, 100]`.
* `0 <= Node.val <= 9`
* It is guaranteed that the list represents a number that does not have leading zeros.$$,
 2, true, ARRAY ['Python', 'JavaScript']);

INSERT INTO "Problems"("ProblemId", "Title", "TestCode", "Description", "Difficulty", "Solution", "TemplateCode") VALUES
(3, 'Longest Substring Without Repeating Characters',
 ARRAY ['Python', 'JavaScript'],
 $$Given a string `s`, find the length of the **longest substring** without repeating characters.

<br>

**Example 1:**

    Input: s = "abcabcbb"
    Output: 3
    Explanation: The answer is "abc", with the length of 3.

**Example 2:**

    Input: s = "bbbbb"
    Output: 1
    Explanation: The answer is "b", with the length of 1.

**Example 3:**

    Input: s = "pwwkew"
    Output: 3
    Explanation: The answer is "wke", with the length of 3.
    Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

**Example 4:**

    Input: s = ""
    Output: 0

<br>

**Constraints:**

* <code>0 <= s.length <= 5 * 10<sup>4</sup></code>
* `s` consists of English letters, digits, symbols and spaces.$$,
 2, true, ARRAY ['Python', 'JavaScript']);

INSERT INTO "Problems"("ProblemId", "Title", "TestCode", "Description", "Difficulty", "Solution", "TemplateCode") VALUES
(4, 'Median of Two Sorted Arrays',
 ARRAY ['Python', 'JavaScript'],
 $$Given two sorted arrays `nums1` and `nums2` of size `m` and `n` respectively, return **the median** of the two sorted arrays.

The overall run time complexity should be `O(log (m+n))`.

<br>

**Example 1:**

    Input: nums1 = [1,3], nums2 = [2]
    Output: 2.00000
    Explanation: merged array = [1,2,3] and median is 2.

**Example 2:**

    Input: nums1 = [1,2], nums2 = [3,4]
    Output: 2.50000
    Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

**Example 3:**

    Input: nums1 = [0,0], nums2 = [0,0]
    Output: 0.00000

**Example 4:**

    Input: nums1 = [], nums2 = [1]
    Output: 1.00000

**Example 5:**

    Input: nums1 = [2], nums2 = []
    Output: 2.00000

<br>

**Constraints:**

* `nums1.length == m`
* `nums2.length == n`
* `0 <= m <= 1000`
* `0 <= n <= 1000`
* `1 <= m + n <= 2000`
* <code>-10<sup>6</sup> <= nums1[i], nums2[i] <= 10<sup>6</sup></code>$$,
 3, false, ARRAY ['Python', 'JavaScript']);

INSERT INTO "Problems"("ProblemId", "Title", "TestCode", "Description", "Difficulty", "Solution", "TemplateCode") VALUES
(5, 'Longest Palindromic Substring',
 ARRAY ['Python', 'JavaScript'],
$$Given a string `s`, return *the longest palindromic substring* in `s`.

<br>

**Example 1:**

    Input: s = "babad"
    Output: "bab"
    Note: "aba" is also a valid answer.

**Example 2:**

    Input: s = "cbbd"
    Output: "bb"

**Example 3:**

    Input: s = "a"
    Output: "a"

**Example 4:**

    Input: s = "ac"
    Output: "a"

<br>

**Constraints:**

* `1 <= s.length <= 1000`
* `s` consist of only digits and English letters.$$,
 2, true, ARRAY ['Python', 'JavaScript']);

INSERT INTO "Problems"("ProblemId", "Title", "TestCode", "Description", "Difficulty", "Solution", "TemplateCode") VALUES
(6, 'ZigZag Conversion',
 ARRAY ['Python', 'JavaScript'],
 $$The string `"PAYPALISHIRING"` is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

    ```
    P   A   H   N
    A P L S I I G
    Y   I   R
    ```

    And then read line by line: `"PAHNAPLSIIGYIR"`

    Write the code that will take a string and make this conversion given a number of rows:

    ```
    string convert(string s, int numRows);
    ```

    <br>

    **Example 1:**

        Input: s = "PAYPALISHIRING", numRows = 3
        Output: "PAHNAPLSIIGYIR"

    **Example 2:**

        Input: s = "PAYPALISHIRING", numRows = 4
        Output: "PINALSIGYAHRPI"

        Explanation:
        ```
        P     I    N
        A   L S  I G
        Y A   H R
        P     I
        ```

    **Example 3:**

        Input: s = "A", numRows = 1
        Output: "A"

    <br>

    **Constraints:**

    * `1 <= s.length <= 1000`
    * `s` consists of English letters (lower-case and upper-case), `','` and `'.'`.
    * `1 <= numRows <= 1000`$$,
 2, false, ARRAY ['Python', 'JavaScript']);

INSERT INTO "Problems"("ProblemId", "Title", "TestCode", "Description", "Difficulty", "Solution", "TemplateCode") VALUES
(7, 'Reverse Integer',
 ARRAY ['Python', 'JavaScript'],
 $$Given a signed 32-bit integer `x`, return `x` with its digits reversed. If reversing `x` causes the value to go outside the signed 32-bit integer range `[-2^31, 2^31 - 1]`, then return `0`.

    Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

    <br>

    **Example 1:**

        Input: x = 123
        Output: 321

    **Example 2:**

        Input: x = -123
        Output: -321

    **Example 3:**

        Input: x = 120
        Output: 21

    **Example 4:**

        Input: x = 0
        Output: 0

    <br>

    **Constraints:**

    * <code>-2<sup>31</sup> <= x <= 2<sup>31</sup> - 1</code>$$,
 2, true, ARRAY ['Python', 'JavaScript']);

INSERT INTO "Problems"("ProblemId", "Title", "TestCode", "Description", "Difficulty", "Solution", "TemplateCode") VALUES
(8, 'String to Integer (atoi)',
 ARRAY ['Python', 'JavaScript'],
 $$Implement the `myAtoi(string s)` function, which converts a string to a 32-bit signed integer (similar to C/C++'s `atoi` function).

    The algorithm for `myAtoi(string s)` is as follows:

    1. Read in and ignore any leading whitespace.
    2. Check if the next character (if not already at the end of the string) is `'-'` or `'+'`. Read this character in if it is either. This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
    3. Read in next the characters until the next non-digit character or the end of the input is reached. The rest of the string is ignored.
    4. Convert these digits into an integer (i.e. `"123" -> 123`, `"0032" -> 32`). If no digits were read, then the integer is `0`. Change the sign as necessary (from step 2).
    5. If the integer is out of the 32-bit signed integer range `[-2^31, 2^31 - 1]`, then clamp the integer so that it remains in the range. Specifically, integers less than `-2^31` should be clamped to `-2^31`, and integers greater than `2^31 - 1` should be clamped to `2^31 - 1`.
    6. Return the integer as the final result.

    **Note:**

    * Only the space character `' '` is considered a whitespace character.
    * **Do not ignore any characters other than the leading whitespace or the rest of the string after the digits.**

    <br>

    **Example 1:**

        Input: s = "42"
        Output: 42
        Explanation: The underlined characters are what is read in, the caret is the current reader position.

            "42" (the underlined portion is the result)

    **Example 2:**

        Input: s = "   -42"
        Output: -42
        Explanation: The underlined characters are what is read in, the caret is the current reader position.

            "   -42" (the underlined portion is the result)

    **Example 3:**

        Input: s = "4193 with words"
        Output: 4193
        Explanation: The underlined characters are what is read in, the caret is the current reader position.

            "4193" (the underlined portion is the result)

    **Example 4:**

            Input: s = "words and 987"
            Output: 0
            Explanation: The underlined characters are what is read in, the caret is the current reader position.

                "words and 987" (the underlined portion is the result)

    **Example 5:**

                Input: s = "-91283472332"
                Output: -2147483648
                Explanation: The number "-91283472332" is out of the range of a 32-bit signed integer.
                Thefore INT_MIN (−2^31) is returned.

    <br>

    **Constraints:**

    * `0 <= s.length <= 200`
    * `s` consists of English letters (lower-case and upper-case), digits, `' '`, `'+'`, `'-'`, and `'.'`. $$,
    2, false, ARRAY ['Python', 'JavaScript']);

INSERT INTO "Problems"("ProblemId", "Title", "TestCode", "Description", "Difficulty", "Solution", "TemplateCode") VALUES
(9, 'Palindrome Number',
 ARRAY ['Python', 'JavaScript'],
 $$Given an integer `x`, return `true` if `x` is a palindrome integer.

    An integer is a **palindrome** when it reads the same backward as forward. For example, `121` is palindrome while `123` is not.

    <br>

    **Example 1:**

        Input: x = 121
        Output: true

    **Example 2:**

        Input: x = -121
        Output: false
        Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.

    **Example 3:**

        Input: x = 10
        Output: false
        Explanation: Reads 01 from right to left. Therefore it is not a palindrome.

    **Example 4:**

        Input: x = -101
        Output: false

    <br>

    **Constraints:**

    * <code>-2<sup>31</sup> <= x <= 2<sup>31</sup> - 1</code>$$,
    1, false, ARRAY ['Python', 'JavaScript']);

INSERT INTO "Problems"("ProblemId", "Title", "TestCode", "Description", "Difficulty", "Solution", "TemplateCode") VALUES
(10, 'Roman to Integer',
 ARRAY ['Python', 'JavaScript'],
 $$Roman numerals are represented by seven different symbols: `I`, `V`, `X`, `L`, `C`, `D` and `M`.

    ```
    Symbol       Value
    I             1
    V             5
    X             10
    L             50
    C             100
    D             500
    M             1000
    ```

    For example, `2` is written as `II` in Roman numeral, just two one's added together. `12` is written as `XII`, which is simply `X + II`. The number `27` is written as `XXVII`, which is `XX + V + II`.

    Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not `IIII`. Instead, the number four is written as `IV`. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as `IX`. There are six instances where subtraction is used:

    * `I` can be placed before `V` (5) and `X` (10) to make 4 and 9.
    * `X` can be placed before `L` (50) and `C` (100) to make 40 and 90.
    * `C` can be placed before `D` (500) and `M` (1000) to make 400 and 900.

    Given a roman numeral, convert it to an integer.

    <br>

    **Example 1:**

        Input: s = "III"
        Output: 3

    **Example 2:**

        Input: s = "IV"
        Output: 4

    **Example 3:**

        Input: s = "IX"
        Output: 9

    **Example 4:**

        Input: s = "LVIII"
        Output: 58
        Explanation: L = 50, V= 5, III = 3.

    **Example 5:**

        Input: s = "MCMXCIV"
        Output: 1994
        Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

    <br>

    **Constraints
    * `1 <= s.length <= 15`
    * `s` contains only the characters `('I', 'V', 'X', 'L', 'C', 'D', 'M')`.
    * It is **guaranteed** that `s` is a valid roman numeral in the range `[1, 3999]`. $$,
    1,
 true, ARRAY ['Python', 'JavaScript']);

INSERT INTO "ClassProblem" VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(2, 5),
(2, 6),
(2, 7),
(2, 8),
(2, 9),
(2, 10);

INSERT INTO "Topics" VALUES
(1, 'Array'),
(2, 'Hash Table'),
(3, 'Linked List'),
(4, 'Math'),
(5, 'Two Pointers'),
(6, 'String'),
(7, 'Binary Search'),
(8, 'Divide and Conquer'),
(9, 'Dynamic Programming'),
(10, 'Backtracking');

INSERT INTO "ProblemTopic" VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(3, 5),
(3, 6),
(4, 7),
(4, 8),
(5, 9),
(5, 10),
(6, 1),
(6, 2),
(7, 3),
(7, 4),
(8, 5),
(8, 6),
(9, 7),
(9, 8),
(10, 9),
(10, 10);

INSERT INTO "ClassUser" VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6);