# JSFW.ScreenDefinition
화면정의 프로그램  (( 💙 내가 가장 애정을 가진 프로그램 중 하나! 💙 ))

목적 : PL이 된다면? 이란 가정으로 화면정의 프로그램!!
 내 잔머리를 죄다 굴려서 만든 프로그램... 드로잉 구현이 너무 어려워!!
 다음엔 상용컨트롤을 쓰면? 어떨까?? 라고 고민이 된다. 요새는 web인데... 
 
 유튜브 영상을 안만들어놨네. 
 
```diff 
+ 추후 : 기회가 되면 터치패널에서 손가락 터치로 그리기를 on/off 가능하게 했으면 하는데... 
```

- 메인화면
![image](https://user-images.githubusercontent.com/116536524/198243782-3f6dbb34-4383-4908-8478-753ca9611c88.png)

- 화면 기획 ( 드로잉 가능 )
![image](https://user-images.githubusercontent.com/116536524/198244422-68e1bcd0-6413-4c61-84df-fda0be6fa9dc.png)

- 화면 기능 정의
![image](https://user-images.githubusercontent.com/116536524/198244748-7e19bc4f-c63d-4ff3-9fe2-28839f0dabb8.png)

- 화면 디자인 ( 드래그 드랍으로 컨트롤들 배치 )
![image](https://user-images.githubusercontent.com/116536524/198244507-66d58305-3840-4b00-a99c-f52b18eee6c9.png)
 
 
 


--- 
- 캡쳐 프로그램!<br />
 : 배경이미지 적용시 화면캡쳐 기능을 구현. ( 기능을 구현 안해놔서 추가 함 22.11.04 )
[GreenShot](https://github.com/greenshot/greenshot)

 : 캡쳐 후 저장파일 경로를 이 프로그램에 맞추어 수정하여 dll만 참조<br />
   ( 필요시 git에서 다운받아 수정하여 사용. git에 소스를 올리면 안될 것 같아 dll만 참조 )<br />
 : WebBrowser 캡쳐 잘해주는 프로그램<br />
 
 ```diff
- 그린샷에서 log4net 사용하고 있으니 보안관련 확인이 필요함. 
- ( 전에 log4 관련 보안이슈가 있었는데... )
```

# 오픈시 에러 <br />
![image](https://user-images.githubusercontent.com/116536524/199480119-f075653d-f3d4-4d96-837a-71001abad05a.png)

해결방법 <br />
파워쉘 : C:\Windows\System32> gci -Recurse "프로젝트가 있는 폴더경로" | Unblock-File <br />
  (( .sln 파일이 있는 폴더에 해주면 된다. )) <br />
참조 : https://happytomorrow.net/217


