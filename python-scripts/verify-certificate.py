from Crypto import Random
from Crypto.Signature import pkcs1_15
from Crypto.PublicKey import RSA
from Crypto.Hash import SHA256
import base64, json

def decode_base64(b64):
    return base64.b64decode(b64)

def encode_base64(p):
    return base64.b64encode(p).decode('ascii')

def make_cert_hash(name, pubKeyBase64):
	message = # 해시 생성 방법 -> H(name + pubKey)
	return SHA256.new(message.encode('utf-8'))

def read_as_json():
	json_str = decode_base64(input()).decode('utf-8')
	json_obj = json.loads(json_str)
	return json_obj

# https://pycryptodome.readthedocs.io/en/latest/src/signature/pkcs1_v1_5.html
def verify(hash, key, signature):
    # PKCS #1 v1.5 를 이용한 전자서명 검증, 성공시 True, 실패시 False 리턴

cert = read_as_json()

hash_compare = # 비교할 해시 생성
server_pubkey = # bytes:서버 공개키 (HINT: JSON에는 BASE64 형태로 제공되어 있음)
signature = # bytes:서버 서명 (HINT: JSON에는 BASE64 형태로 제공되어 있음)

cert['isValid'] = # 인증서 내 서명 검증

json_str = json.dumps(cert).encode('utf-8')

print(encode_base64(json_str))