'''
Python RESTful API

RESTful API sandbox with request module.
'''

# Module Imports
import json
import requests

url = "http://api.open-notify.org/astros.json"

def json_print(obj):
    # Create a formatted string of a json object
    text = json.dumps(obj, sort_keys = True, indent = 4)
    print(text)

response = requests.get(url)

# Print response code
print(response.status_code)

# Print response content
json_print(response.json())