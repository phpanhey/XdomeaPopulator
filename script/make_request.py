import requests
import zipfile
from dotenv import load_dotenv
import os

def main():
    name = "10000000-0000-0000-0000-000000000000_FVDaten.SGOAblegen.0605"
    make_zip(name)
    make_request(name)


def make_zip(name):    
    file_name = "10000000-0000-0000-0000-000000000000_file.txt"
    with open(file_name, "w") as f:
        f.write("hello world\n")
    

    with zipfile.ZipFile(name + ".zip", "w", zipfile.ZIP_DEFLATED) as z:
        z.write(name + ".xml")
        z.write(file_name)

    print("ZIP created:", name + ".zip")


def make_request(name):

    load_dotenv()
    username = os.getenv("USER")
    password = os.getenv("PW")
    url = os.getenv("URL")
    mandant_id_key = os.getenv("MANDANTIDKEY")
    mandant_id = os.getenv("MANDANTID")

    headers = {
        mandant_id_key: mandant_id
    }


    zip_path = name + ".zip"

    files = {
        "file": (zip_path, open(zip_path, "rb"), "application/zip")
    }

    auth = (username, password)

    response = requests.post(
        url,
        headers=headers,
        files=files,
        auth=auth  # remove if not needed
    )

    print("Status:", response.status_code)
    print("Response:", response.text)


if __name__ == "__main__":
    main()

