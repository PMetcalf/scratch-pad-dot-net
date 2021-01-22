'''
Python RESTful API

RESTful API sandbox with request module.
'''

# Module Imports
import requests

url = "http://api.open-notify.org/astros.json"

response = requests.get(url)

# Print response code
print(response.status_code)

# Print response content
print(response.json())