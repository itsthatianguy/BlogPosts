from sqlalchemy import Integer, String, ForeignKey
from sqlalchemy.sql.schema import Column
from sqlalchemy.orm import relationship
from ..database import Base


class Job(Base):
    __tablename__ = 'jobs'

    id = Column(Integer, primary_key=True)
    title = Column(String, nullable=False)
    description = Column(String, nullable=False)

    company_id = Column(Integer, ForeignKey('companies.id'))
    company = relationship("Company", back_populates="jobs")
