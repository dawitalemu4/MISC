from datetime import date

def calculate_age(dob):
    today = date.today() 
    split_date = dob.split("-")
    formatted_date = date(int(split_date[0]), int(split_date[1]), int(split_date[2]))
    age_days = abs(formatted_date - today)
    age_years = abs(age_days.days / 356)
    return int(age_years) 