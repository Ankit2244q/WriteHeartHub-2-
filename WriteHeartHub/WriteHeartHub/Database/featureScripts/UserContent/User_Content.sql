CREATE DATABASE Write_Heart_Db

CREATE TABLE UserContent (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Unique identifier for the content, auto-incremented
    UserId NVARCHAR(255) NOT NULL,    -- Identifier for the user who created the content
    Type INT NOT NULL,                 -- Type of content (Post, Story, Thought, Quote, Lyrics)
    Content NVARCHAR(MAX) NOT NULL,    -- The actual content (text, lyrics, etc.)
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Timestamp of when the content was created
    UpdatedAt DATETIME NULL,           -- Timestamp of when the content was last updated
    Tags NVARCHAR(MAX) NULL             -- Optional tags for categorization (can be stored as a comma-separated string)
);

INSERT INTO UserContent (UserId, Type, Content, CreatedAt, UpdatedAt, Tags) VALUES
('user123', 1, 'This is my first post!', GETDATE(), NULL, 'introduction, first'),
('user456', 2, 'Today was a great day at the park!', GETDATE(), NULL, 'outdoor, fun'),
('user789', 3, 'Sometimes, you just need to take a break and breathe.', GETDATE(), NULL, 'self-care, thoughts'),
('user123', 4, 'The only limit to our realization of tomorrow is our doubts of today.', GETDATE(), NULL, 'inspiration, motivation'),
('user456', 5, 'Imagine all the people living life in peace.', GETDATE(), NULL, 'lyrics, peace'),
('user789', 1, 'Just finished reading a fantastic book!', GETDATE(), NULL, 'books, reading'),
('user123', 3, 'Gratitude turns what we have into enough.', GETDATE(), NULL, 'gratitude, mindset'),
('user456', 4, 'Do not wait to strike till the iron is hot, but make it hot by striking.', GETDATE(), NULL, 'quotes, action'),
('user789', 2, 'Had a wonderful time with friends at the beach!', GETDATE(), NULL, 'friends, beach'),
('user123', 5, 'And in the end, the love you take is equal to the love you make.', GETDATE(), NULL, 'lyrics, love');



-- Optional: Create a UserType table to store content types
CREATE TABLE ContentType (
    Id INT PRIMARY KEY,                -- Unique identifier for the content type
    Name NVARCHAR(50) NOT NULL         -- Name of the content type (e.g., Post, Story, etc.)
);

-- Insert content types into the ContentType table
INSERT INTO ContentType (Id, Name) VALUES
(1, 'Post'),
(2, 'Story'),
(3, 'Thought'),
(4, 'Quote'),
(5, 'Lyrics');