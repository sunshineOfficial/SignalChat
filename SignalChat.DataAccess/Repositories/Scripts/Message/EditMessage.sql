update messages
set text      = @editedText,
    edited_on = @editedOn
where id = @id;