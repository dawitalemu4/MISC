import re 

def text_match(text): 
    patterns = "^[a-zA-Z]" 

    if re.search(patterns, text): 
        return 'Found a match!' 
    else: 
        return('Not matched!') 

print(text_match("The quick brown fox jumps over the lazy dog.")) 

print(text_match(" The quick brown fox jumps over the lazy dog."))


address = "00216.08.094.196" 

def remove_leading_zeros(ip):
    regEx = "^0+"
    
    search = re.search(regEx, ip)
    zeros_removed = ip[:search.start()] + ip[search.end():]
    return zeros_removed

print(remove_leading_zeros(address))
