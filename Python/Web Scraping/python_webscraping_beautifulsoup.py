'''
Python Webscraping Beautiful Soup

Webscraping sandbox with Beautiful Soup and requests modules.
'''

# Module Imports
import requests

# Constants
URL = 'https://www.monster.com/jobs/search/?q=Software-Developer&where=Liverpool'

# Retrieve page
page = requests.get(URL)