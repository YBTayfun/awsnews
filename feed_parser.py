import json
import os
import feedparser

def load_keywords(file_path):
    with open(file_path, 'r', encoding='utf-8') as file:
        return [line.strip().lower() for line in file]

def parse_rss_to_json(rss_url, output_file, keywords):
    feed = feedparser.parse(rss_url)

    if os.path.exists(output_file):
        with open(output_file, 'r', encoding='utf-8') as f:
            existing_items = json.load(f)
        existing_guids = {item['guid'] for item in existing_items}
    else:
        existing_items = []
        existing_guids = set()

    for post in feed.entries:
        title = getattr(post, 'title', 'No Title').lower()
        description = getattr(post, 'description', 'No Description').lower()

        # Check if any of the keywords are in the title or description
        if not any(keyword in title or keyword in description for keyword in keywords):
            continue  # Skip this post

        guid = getattr(post, 'id', 'No GUID')
        if guid not in existing_guids:
            item = {
                'guid': guid,
                'title': title,
                'link': getattr(post, 'link', 'No Link'),
                'date': getattr(post, 'published', 'No Date'),
                'description': description
            }
            existing_items.append(item)
            

    with open(output_file, 'w', encoding='utf-8') as f:
        json.dump(existing_items, f, ensure_ascii=False, indent=4)

# Load keywords from a file
keywords_file = '../../../keywords.txt'
keywords = load_keywords(keywords_file)

rss_urls = [
    "https://www.ntv.com.tr/turkiye.rss",
    "https://t24.com.tr/rss",
    "https://t24.com.tr/rss/haber/politika",
    "https://t24.com.tr/rss/haber/gundem",
    "https://www.aa.com.tr/tr/rss/default?cat=guncel",
    "https://www.cnnturk.com/feed/rss/turkiye/news",
    "https://feeds.bbci.co.uk/turkce/rss.xml"
]

for rss_url in rss_urls:
    output_file = 'feed_data1.json'  # Consider using unique filenames for each RSS feed
    parse_rss_to_json(rss_url, output_file, keywords)