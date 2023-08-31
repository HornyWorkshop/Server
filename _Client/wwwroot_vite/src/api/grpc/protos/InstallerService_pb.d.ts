import * as jspb from 'google-protobuf'



export class InstallRequest extends jspb.Message {
  getGuid(): string;
  setGuid(value: string): InstallRequest;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): InstallRequest.AsObject;
  static toObject(includeInstance: boolean, msg: InstallRequest): InstallRequest.AsObject;
  static serializeBinaryToWriter(message: InstallRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): InstallRequest;
  static deserializeBinaryFromReader(message: InstallRequest, reader: jspb.BinaryReader): InstallRequest;
}

export namespace InstallRequest {
  export type AsObject = {
    guid: string,
  }
}

export class InstallResponse extends jspb.Message {
  getResult(): boolean;
  setResult(value: boolean): InstallResponse;

  getMessage(): string;
  setMessage(value: string): InstallResponse;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): InstallResponse.AsObject;
  static toObject(includeInstance: boolean, msg: InstallResponse): InstallResponse.AsObject;
  static serializeBinaryToWriter(message: InstallResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): InstallResponse;
  static deserializeBinaryFromReader(message: InstallResponse, reader: jspb.BinaryReader): InstallResponse;
}

export namespace InstallResponse {
  export type AsObject = {
    result: boolean,
    message: string,
  }
}

