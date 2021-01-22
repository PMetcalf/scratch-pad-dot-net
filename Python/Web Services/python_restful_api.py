'''
Python RESTful API

RESTful API sandbox with request module.
'''

# Module Imports
import requests

url = "http://api.open-notify.org/astros.json"

response = requests.get(url)

print(response.status_code)