
# Book Library Application

This is a simple Application that can be used to catalogue books,
Books added can have Authors and Categories, A List of Favorite books
can also be created. it is a [CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete#:~:text=In%20computer%20programming%2C%20create%2C%20read,computer%2Dbased%20forms%20and%20reports.) 
[RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer) web API built using .Net 5 Framework.



## Run Locally

Clone the project

```bash
  https://github.com/IbrahimIbrahim-O/BookLibraryApplication.git
```

Go to the project directory

```bash
  cd BookLibraryApplication
```

Delete the Migrations folder


Run your Migration in the CLI

```bash
  dotnet ef migrations add MyFirstMigration
```

Update Database

```bash
  dotnet ef database update
```

Run the project and test endpoints with seeded data, new data can also be added to test endpoints.
## Book Catalogue Features

- Get all books
- Get a single book
- Add New Book
- Add books to favorite list
- Get List of favorite books
- Delete books and category
## API description

- ``` GET/api/book/getallbooks.``` Returns All Books in the Books Application.
- ``` GET/api/book/getbookbyid{id}.``` Returns a single book by id.
- ``` POST/api/book/addbook.``` Adds a new book with authors to the Application.
- ``` PUT/api/book/updatebook/{bookid}.``` Updates a book by the provided id.
- ``` POST/api/book/addbookstofavoritelist``` Adds books to favorite list.




## Authors

- [@Ibrahim Ibrahim](https://github.com/IbrahimIbrahim-O)


##  About Me
- Back end developer (.Net, Web Api, Entity Framework, Sql)
- Project Management Professional(PMP)
- Microsoft Certified - Azure Associate




## Acknowledgements

 - [Stack Overflow](https://stackoverflow.com)
 - [How to write a Good readme](https://bulldogjob.com/news/449-how-to-write-a-good-readme-for-your-github-project)
 - [C-sharpcorner](https://www.c-sharpcorner.com)
## License

[MIT](https://choosealicense.com/licenses/mit/)

