# Basic Database Migrations with SQLAlchemy and Alembic

This is an example of how to create and run Alembic migrations for SQLAlchemy to create tables and set up a one-to-many relationship between the tables using `ForeignKeyConstraint`.  
The blog post this code accompanies can be found here: [https://ianrufus.com/blog/2020/12/sqlalchemy-alembic-migrations](https://ianrufus.com/blog/2020/12/sqlalchemy-alembic-migrations)

## Getting Started

Included in the example is a Docker Compose file to run the API and a Postgres database.  

Create a virtual environment for the Python API:  
`python3 -m venv virtualenv`

Activate the environment:  
`source virtualenv/bin/activate`

Then install the required dependencies:  
`pip install -r requirements.txt`

The first step is to build the required container for the API:  
`docker-compose build`

Once built, you can run the API and Database:  
`docker-compose up`

In another terminal you can run the migrations with:  
`alembic upgrade head`

If you want to revert the migration, you can run:  
`alembic downgrade -1`
