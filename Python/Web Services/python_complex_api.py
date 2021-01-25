'''
Python Complex API

Workiing with a RESTful API with authentication, rate limiting and pagination.
'''

# Module Imports
from IPython.core.display import clear_output
import json
import pandas as pd
import requests
import requests_cache
import time

# Constants
APPLICATION_NAME = "API Sandbox App"
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

# --- Retrieving Paginated Data --- 

# Install cache
cache_string = r'C:\Developer\scratch-pad\Python\Web Services\response_cache'
requests_cache.install_cache(cache_name = cache_string)

# Initialise list for results
results = []

# Set initial page and high total number
page = 1
total_pages = 99999

# Retrieve paginated data
while page <= total_pages:

    payload = {
        'method': 'chart.gettopartists',
        'limit': 500,
        'page': page
    }

    print("Requesting page {}/{}".format(page, total_pages))
    clear_output(wait = True)

    # Get the API response
    response = lastfm_get(payload)

    # Error handling
    if response.status_code != 200:
        print(response.text)
        break

    # Extract pagination
    page = int(response.json()['artists']['@attr']['page'])
    total_pages = int(response.json()['artists']['@attr']['totalPages']) 

    # Append results to list
    results.append(response)

    # Wait for a period if not cached result
    if not getattr(response, 'from_cache', False):
        time.sleep(0.25)

    # Increment page
    page += 1

# --- Processing Data with Pandas ---

# Filter response
r0 = responses[0]
r0_json = r0.json()
r0_artists = r0_json['artists']['artist']

# Create dataframe from filtered response
r0_df = pd.DataFrame(r0_artists)
r0_df.head()