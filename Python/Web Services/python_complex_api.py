'''
Python Complex API

Workiing with a RESTful API with authentication, rate limiting and pagination.
'''

# Module Imports
import json
import requests

# Constants
APPLICATION_NAME = "API Sandbox App"
API_KEY = "ad927174be69fdf7dbe167638cbc1184"
REGISTERED_TO = "paul_metcalf_uk"
USER_AGENT = "CloudforestTech"

def lastfm_get(payload):

    # Define headers and url
    headers = {'user-agent': USER_AGENT}
    last_fm_url = "http://ws.audioscrobbler.com/2.0/"

    # Add API key and format to payload
    payload['api_key'] = API_KEY
    payload['format'] = 'json'

    # Get response
    response = requests.get(last_fm_url, headers = headers, params = payload)
    return response

def json_print(obj):
    # Create a formatted string of a json object
    text = json.dumps(obj, sort_keys = True, indent = 4)
    print(text)

#--- Retrieving Paginated Data --- 

# Initialise list for results
results = []

# Set initial page and high total number
page = 1
total_pages = 99999

# Retrieve paginated data
while page > total_pages:

    response = lastfm_get({'method': 'chart.gettopartists'})


