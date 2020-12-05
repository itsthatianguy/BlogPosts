from sqlalchemy import Integer, String
from sqlalchemy.sql.schema import Column
from sqlalchemy.orm import relationship
from ..database import Base


class Company(Base):
    __tablename__ = 'companies'

    id = Column(Integer, primary_key=True)
    name = Column(String, nullable=False)

    jobs = relationship("Job", back_populates="company")
