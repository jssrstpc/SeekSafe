# SeekSafe
Lost and Found Management System

(SYSTEM FLOW DRAFT)

USER REGISTRATION: a. Users can register in the app by providing their university ID number, full name, username, password, email, phone number, and selecting their role and department. (Password must be re-entered).

USERS WHO WANTS TO REPORT FOUND ITEM: a. User will login using id number and password. b. Users can report found item by providing details such as item category, item name, description, location, date, and image (optionally). User can click “Proceed” button to proceed. -Dli guro optional ang image needed jud dapat naay pic kay if kana nakit.an na item wla pa sa ato system naa tay magamit na iamge na ma post. c. After clicking “Proceed” button, users will be directed to Lost Item section to check if there is an item match to the found item. d. At the Lost Item section, user can check if there is an item match to the item found. e. If there is an item match in the Lost Item section, user can click “Item Found” button to the specific lost item. After clicking “Item Found” button, user will be directed to next page where user will be asked to select a return method (ex. Return item to SAO, or contact owner via in-app messaging or phone number). After selecting a return method, it will generate a message depending on the selected return method: i. If user selected a return method (Return item to SAO), it will state a message “Thank you for reporting the found item! Please bring the item to the Student Affairs Office (SAO) at your earliest convenience.”) User will click “Ok” button and upon clicking the “Ok” button, lost item reporter must automatically receive a notification stating "Your item has been found! We'll provide you with further updates once the item has been successfully returned to Student Affairs Office (SAO)” and found item reporter will also automatically receive a message stating “We've let the owner know that someone found their lost item.”. If Item will not be returned to SAO after 24 hours, user will automatically receive a notification stating "Please consider delivering the found item to the Student Affairs Office (SAO) at your earliest convenience. Your assistance in this matter is greatly appreciated. Thank you."

ii. Else, if user selected a return method (contact owner via in-app messaging or phone number), it will state a message "Thanks for reporting! You'll soon receive a notification with the owner's contact details”. Once user received the notification containing the owner’s contact information, user can now contact the owner via in-app messaging or phone number. f. Else, if there is no match item in the Lost Item section, user can click the “No Match Item” button and user will be directed to next page where user will be asked to select a return method (ex. Return item to SAO, or contact owner via in-app messaging or phone number). After selecting a return method, it will generate a message depending on the selected return method: -ang sa matching sa items ba through description na ge hatag sa naka found or naay list sa lost item nya siya ra mangita like example naay category nga cellphone inig click ato mo gawas tanan lost na cellphone nya if naa mo match sa iamge e click ra niya ang image nya adtu na mga steps para mauli or macontact ang owner i. If user selected a return method (Return item to SAO), it will state a message “Thank you for reporting the found item! Please bring the item to the Student Affairs Office (SAO) at your earliest convenience.”)

ii. Else, if user selected a return method (contact owner via in-app messaging or phone number), user will be asked to input full name and phone number. After providing the needed information, it will state a message "Thanks for reporting the found item! You'll soon receive a notification if there is someone who wants to claim your found item." User will automatically receive a notification after 7 days if still no owner who wants to claim the found item stating: "Hello! We wanted to let you know that nobody has claimed the item you found yet. We suggest bringing it to the Student Affairs Office (SAO) for safekeeping until the owner comes forward. Thank you!"

USERS WHO WANTS TO REPORT LOST ITEM: a. User will login using id number and password. b. Users can report lost item by providing details such as item name, description, location, date, and image (optionally). c. After clicking “Proceed” button, users will be directed to Found Item section to check if there is an item match to the lost item. d. At the Found Item section, user can check if there is an item match to the lost item. e. If there is an item match in the Found Item section, user can click “Claim Item” button to the specific found item. After clicking “Claim Item” button, user will be directed to next page where user will be asked to select a claim method (ex. Claim item to SAO, or contact returner via in-app messaging or phone number). After selecting a return method, it will generate a message depending on the selected return method: i. If user selected a return method (Claim item to SAO), it will state a message “Thank you for reporting the lost item! We will verify your claim request and you will receive a notification once confirmed”. Once user received the verification confirmation, user can now claim the item to SAO office
ii. Else, if user selected a claim method (contact the returner via in-app messaging or phone number), it will state a message "Thanks for reporting the lost item! You'll soon receive a notification with the returner’s contact details”. Once the user received a notification containing the returner’s contact information, user can now contact the returner via in-app messaging or phone number. f. Else, if there is no match item in the Found Item section, user can click the “No Match Item” button and user will be directed to next page where user will be asked to select a claim method (ex. Claim item to SAO, or contact returner via in-app messaging or phone number). After selecting a return method, it will generate a message depending on the selected return method: i. If user selected a return method (Claim item to SAO), it will state a message “Thank you for reporting the lost item! You'll soon receive a notification if there is someone who wants to return your lost item."

ii. Else, if user selected a return method (contact returner via in-app messaging or phone number), user will be asked to input full name and phone number. After providing the needed information, it will state a message "Thanks for reporting the lost item! You'll soon receive a notification if there is someone who wants to return the lost item."

FOUND ITEM MANAGEMENT: a. If SAO received a report from user who found an item, where there is an item matched at the lost item section, i. If returner’s preferred return method is (Return item to SAO), if item was successfully received at the Student Affairs Office (SAO), admin will set the status of the lost and found item to Returned. Once the admin set the status to returned, found item reporter and lost item reporter will receive a notification to verify the returned item. Found item reporter will automatically get a star in the profile and will be included to hero section as an appreciation.
ii. If returner’s preferred return method is (contact owner via in-app messaging or phone number), admin will send a notification to the user who reported the lost item stating “Your item has been found! You can directly contact the person who found the item via in-app messaging or phone number”. b. If SAO received a report from user who found an item, where there is no item matched at the lost item section, i. If returner’s preferred return method is (Return item to SAO), if item was successfully received at the Student Affairs Office (SAO), admin will set the status of the found item to Returned (Claim at Student Affairs Office (SAO)). Since item was successfully returned to SAO, found item reporter will receive a notification to verify the returned item. Found item reporter will automatically get a star in the profile and will be included to hero section as an appreciation.

ii. If returner’s preferred return method is (contact owner via in-app messaging or phone number), if no one claims the found item after 7 days, returner will suppose receive a notification to return just bring the item to SAO. If item was successfully received at the Student Affairs Office (SAO), admin will set the status of the found item to Returned (Claim at Student Affairs Office (SAO)). Since item was successfully returned to SAO, found item reporter will receive a notification to verify the returned item. Found item reporter will automatically get a star in the profile and will be included to hero section as an appreciation.

LOST ITEM MANAGEMENT: a. If SAO received a report from user who lost an item, where there is an item matched at the found item section, i. If lost item reporter’s preferred return method is (Return item to SAO), if item was successfully claimed at the Student Affairs Office (SAO), admin will set the status of the lost and found item to Returned. Once the admin set the status to returned, lost item reporter and found item reporter will receive a notification to verify the returned item. Found item reporter will automatically get a star in the profile and will be included to hero section as an appreciation. ii. If lost item reporter’s preferred return method is (contact owner via in-app messaging or phone number), after 7 days, returner should bring the item to SAO and if item was successfully claimed, admin will set the status to returned after lost item reporter and found item reporter verified the returned item. Found item reporter then, will automatically get a star in the profile and will be included to hero section as an appreciation.

