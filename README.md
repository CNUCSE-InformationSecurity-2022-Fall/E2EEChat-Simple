# E2EEChat-Simple
11~14주차 과제: E2EE 채팅 프로그램 

* [패키지 다운로드](https://github.com/CNUCSE-InformationSecurity-2022-Fall/E2EEChat-Simple/releases/tag/assignment-2)
* 과제 수행을 위한 파이썬 스크립트는 압축 파일 내에 있습니다.


![image](https://user-images.githubusercontent.com/13935811/203414191-777a2ef0-bde4-4c43-b89f-33408045f93e.png)

## 테스트용 인증서 정보

### JSON Specification

```
{
    "name": string,
    "hash": string (hex),
    "pubKey": base64,
    "serverPubKey": base64,
    "signature": base64
}
```

### 테스트 정보

![image](https://user-images.githubusercontent.com/13935811/205376355-a4a4de99-9680-4e81-b395-4598a1ec8b59.png)

* 테스트용 사용자 (조교허강준) 공개키
```
-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAlSZnxE+EM7z4vVFRcApZ
w1OqA3bLIjsXkVNKRMIu9DWULxPVjgNrX/DNz+1Wmept8AgNMqGif31oXVVYKesN
ECmDH0GhlGp2hzEOv6ftm2eBokPFXE3Y8tz+CN6hVDdeSXec3EeTZHVHO2vCsFdZ
OGcgVc9vwHYG1X4kh1KW6kA8YsjN7GisK/sBD8piDSygFNaZ0U8XYFn8n/4UW1sj
KMRSDp0epYlwQL4bddBTqzhJ47RVZqcTuPTNHDPyRvPr/vKd/F6jyRYAqJu9/KCX
dlbf82hbU5JUhRinb+VKvYRWAp7P/RbD+jL9lgtiIsONvVuRtoz9SoxDUdndBAF9
lQIDAQAB
-----END PUBLIC KEY-----
```

* 서명용 해시
```
d8682b38c57c83ffe5fc2a0370b96b9477b79da35bdb7779a6b44d46e73aba68
```

* 서버 공개키
```
-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAo5exm5Re195FWz3rqAjk
1mmJN0rbMT1aIpzDdIWh4yKeu9ocFTMYEuwdLgeYifFyCoQQvWbIkZkGPtTjIJSW
NvVYQDGj+niZMcYQ/1Me8PSBI33OX80akqW3fhp8J8ATxjh/vNWFaRs2NH1RTvjQ
t1RIM+XrPm8cd5TB7RcpPnsUIo6vtPPH3baXD4FfwLTroGHnhgDZh6XqrmhZDJD6
rVwIigGtPYQ+4WickewLf6CsScs4cd5V+0NkCKjl5cldE8ECb0mtWxtoZqC/AUsR
YmtvMA70YoNWxvTvwI7XDg643WHTwTY66gTO0vNGhULLCsQLqeuVSZcbdtf2jVdr
JQIDAQAB
-----END PUBLIC KEY-----
```

* 서버 서명
```
hmH9dBZszk+YKysAdzwaoH73qaQzEEwHDsmT71Q9i26/DKtRWmz6LJ1OVtz5w6aEpnnNJFr7gt+uSpQclF8fxtnBpnjm5/bvLWpByOcEAL+VwJv2rYe5ikuZYWAH2ORCHfRSEWZaiEO9o7/wU+jp5e43GNZhVj1saZQ05nZ/iaPQLV5b5gEGv5lN1k4rawGpztMvvS3L7+96xleaOBRAPBCu687vNSIMWfXRWvn5rKlgSRKaNaVWXgwNEYRtiVHLoM9yI8Mg7qhW0ZtobGcjWN1PZizw8jjnbgIIGH355OJflwAavyc9HP2NfMfUg90JnvVTKV6UD+R3onndQufmng==
```


