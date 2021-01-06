'''
Python Webscraping Beautiful Soup

Webscraping sandbox with Beautiful Soup and requests modules.
'''

# Module Imports
from bs4 import BeautifulSoup
import requests

# Constants
URL = 'https://www.monster.com/jobs/search/?q=Software-Developer&where=Liverpool'

# Retrieve page
page = requests.get(URL)

# Start parsing
soup = BeautifulSoup(page.content, 'html.parser')