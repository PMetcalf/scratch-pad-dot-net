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