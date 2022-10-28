Image Uploading Using Swagger locally on machine.
Covered all the endpoints with logging on console. I used repository pattern to implement Image functionality. 
Created a service with BasicImageService and implements IBasicImageService interface. Write the logic inside the service.

Then Registered that service into our application to use that in our controllers as DI.



These are the endpoints 

![Screenshot (17)](https://user-images.githubusercontent.com/116844484/198514501-86e1a38f-b1e3-4081-b1cf-57567de8d732.png)

Swagger documentation of API's 

WITH NEW IMAGE

![Screenshot (18)](https://user-images.githubusercontent.com/116844484/198515063-8cb974c4-b612-4f6f-a710-369b1d12455d.png)

Just simply select image that you want to upload and give that image a name. That file stored on your local machine iself. If the folder name "Images" don't exist it created that and stored that file in that.


GET-IMAGE
To display an image just write the name of the image you want to check. Make sure you entered the right name which you entered while uploading.


![Screenshot (22)](https://user-images.githubusercontent.com/116844484/198516796-f85e46c9-103d-4fc4-8aab-1d9adb861be0.png)


FOR UPDATE

Just Simply Write that name of the image that you want to change and select new image. New Image will be replaced with same name.


ALL FILES

Display all the files name that you uploaded.

![Screenshot (19)](https://user-images.githubusercontent.com/116844484/198516282-a9c8613c-f673-402c-859b-3018f36c2a2e.png)


FOR DELEE

![Screenshot (20)](https://user-images.githubusercontent.com/116844484/198516341-39bc1e84-f67b-48a6-b522-a8454c287bcc.png)

Write the name of the file you want to delete. If file exists it will be deleted.
