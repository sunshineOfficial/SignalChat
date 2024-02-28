update users
set username = coalesce(@Username, username),
    email    = coalesce(@Email, email),
    name     = coalesce(@Name, name),
    surname  = coalesce(@Surname, surname)
where id = @Id;