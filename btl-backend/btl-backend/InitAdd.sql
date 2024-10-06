INSERT INTO "Classes" VALUES
(1, '65KTPM'),
(2, '65CNTT');

INSERT INTO "Users" VALUES (611, 'Phuc', '12345', 0, 1),
                           (636, 'Yen', '12345', 0, 1),
                           (637, 'Ninh', '12345', 0, 1),
                           (638, 'Khanh', '12345', 0, 2),
                           (639, 'Thu', '12345', 0, 2),
                           (640, 'Tung', '12345', 0, 2);

INSERT INTO "Problems" VALUES
(1, 'Two Sum', 'Find numwith two sum', ARRAY ['Python', 'JavaScript']),
(2, 'Add Two Numbers', 'Add two numbers', ARRAY ['Python', 'JavaScript']),
(3, 'Longest Substring Without Repeating Characters', 'Find longest substring without repeating characters', ARRAY ['Python', 'JavaScript']),
(4, 'Median of Two Sorted Arrays', 'Find median of two sorted arrays', ARRAY ['Python', 'JavaScript']),
(5, 'Longest Palindromic Substring', 'Find longest palindromic substring', ARRAY ['Python', 'JavaScript']),
(6, 'ZigZag Conversion', 'Convert string to zigzag', ARRAY ['Python', 'JavaScript']),
(7, 'Reverse Integer', 'Reverse integer', ARRAY ['Python', 'JavaScript']),
(8, 'String to Integer (atoi)', 'Convert string to integer', ARRAY ['Python', 'JavaScript']),
(9, 'Palindrome Number', 'Check if number is palindrome', ARRAY ['Python', 'JavaScript']),
(10, 'Regular Expression Matching', 'Check if string matches regular expression', ARRAY ['Python', 'JavaScript']);

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

INSERT INTO "TestCases" VALUES
(1, '2,7,11,15\n9', '0, 1', 1),
(2, '3,2,4\n6', '1, 2', 1);