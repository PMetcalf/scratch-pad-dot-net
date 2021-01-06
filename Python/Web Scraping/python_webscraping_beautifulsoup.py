'''
Python Webscraping Beautiful Soup

Webscraping sandbox with Beautiful Soup and requests modules.
'''

# Module Imports
from bs4 import BeautifulSoup
import requests

# Constants
URL = 'https://www.monster.co.uk/jobs/search/?q=Python-Developer&where=Liverpool__2C-NW'

# Retrieve page
page = requests.get(URL)

# Start parsing
soup = BeautifulSoup(page.content, 'html.parser')

# Find Elements of interest
results = soup.find(id = 'ResultsContainer')
print(results.prettify())

# Find job elements
job_elems = results.find_all('section', class_ = 'card-content')

# Print data for each element
for job_elem in job_elems:
    # Each job_elem is a new BeautifulSoup object.
    # You can use the same methods on it as you did before.
    title_elem = job_elem.find('h2', class_ = 'title')
    company_elem = job_elem.find('div', class_ = 'company')
    location_elem = job_elem.find('div', class_ = 'location')
    print(title_elem)
    print(company_elem)
    print(location_elem)
    print() # Add a space