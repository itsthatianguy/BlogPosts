"""init

Revision ID: 419599dcaf21
Revises: 
Create Date: 2020-12-05 14:16:30.007456

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = '419599dcaf21'
down_revision = None
branch_labels = None
depends_on = None


def upgrade():
    op.create_table(
        'companies',
        sa.Column('id', sa.Integer, primary_key=True),
        sa.Column('name', sa.String(50), nullable=False),
    )
    op.create_table(
        'jobs',
        sa.Column('id', sa.Integer, primary_key=True),
        sa.Column('description', sa.String(), nullable=False),
        sa.Column('title', sa.String(100), nullable=False),
        sa.Column('company_id', sa.Integer, nullable=False),
        sa.ForeignKeyConstraint(('company_id',), ['companies.id'], ),
    )


def downgrade():
    op.drop_table('jobs')
    op.drop_table('companies')
