update users
set
    username = case when @Username is null then name else @Username end,
    email = case when @Email is null then email else @Email end,
    name = case when @Name is null then name else @Name end,
    surname = case when @Surname is null then surname else @Surname end
where id = @Id;