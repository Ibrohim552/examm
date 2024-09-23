Create database Education_Center_db

Create table Users
(
    Id uuid primary key DEFAULT  gen_random_uuid(),
    FirstName varchar not null unique,
    LastName varchar not null unique,
    Email varchar not null unique,
    PasswordHash varchar not null,
    CreatedAt timestamp default NOW()
);


Create table Categories
(
    Id uuid primary key DEFAULT gen_random_uuid(),
    Name varchar not null unique,
    CreatedAt timestamp default NOW()
);



Create table Tasks
(
    Id uuid primary key DEFAULT  gen_random_uuid(),
    Title varchar not null,
    Description varchar not null,
    IsCompleted bool,
    DueDate timestamp default NOW(),
    UserId uuid ,
    CategoryId uuid,
    Priority varchar not null default 'low',
    CreatedAt timestamp default NOW(), 
    Foreign key(UserId) references Users(Id),
    Foreign key(CategoryId) references Categories(Id)
);



Create table Comments
(
    Id uuid primary key DEFAULT  gen_random_uuid(),
    TaskId uuid,
    UserId uuid,
    Content varchar not null,
    CreatedAt timestamp default NOW(),
    Foreign key(TaskId) references Tasks(Id),
    Foreign key(UserId) references Users(Id)
);

Create table TaskAttachments
(
    Id uuid primary key DEFAULT  gen_random_uuid(),
    TaskId uuid,
    FilePath varchar not null,
    CreatedAt timestamp default NOW(),
    Foreign key(TaskId) references Tasks(Id)
);

Create table TaskHistory
(
    Id uuid primary key DEFAULT  gen_random_uuid(),
    TaskId uuid,
    ChangeDescription varchar not null,
    ChangedAt timestamp default NOW(), 
    Foreign key(TaskId) references Tasks(Id)
);

